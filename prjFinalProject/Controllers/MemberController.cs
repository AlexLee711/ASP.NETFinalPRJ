using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Security;
using prjFinalProject.Models;

namespace prjFinalProject.Controllers
{ 
    [Authorize]
    public class MemberController : Controller
    {
        dbArtsCenterEntities db = new dbArtsCenterEntities();
        public ActionResult Edit(string Code)
        {
            var centers = db.TableCenters1081753.Where(m => m.Code == Code).FirstOrDefault();
            return View("../Home/Edit", "_LayoutMember",centers);
        }

        [HttpPost]
        public ActionResult Edit(TableCenters1081753 centers)
        {
            if (ModelState.IsValid)
            {
                var temp = db.TableCenters1081753.Where(m => m.Code == centers.Code).FirstOrDefault();
                temp.CNName = centers.CNName;
                temp.ENName = centers.ENName;
                temp.Adress = centers.Adress;
                temp.Genre = centers.Genre;
                temp.phone = centers.phone;
                temp.Year = centers.Year;
                temp.descript = centers.descript;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centers);
        }
        public ActionResult Search(string Genre, string searchString, string adress)
        {
            var GenreLst = new List<string>();
            var GenreQry = from d in db.TableCenters1081753 orderby d.Genre select d.Genre;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.Genre = new SelectList(GenreLst);
            var centers = from m in db.TableCenters1081753 select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                centers = centers.Where(s => s.CNName.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(Genre))
            {
                centers = centers.Where(x => x.Genre == Genre);
            }
            if (!String.IsNullOrEmpty(adress))
            {
                centers = centers.Where(a => a.Adress.Contains(adress));
            }
            return View("../Member/Search", "_LayoutMember", centers);
        }
        public ActionResult Create()
        {
            return View("../Member/Create", "_LayoutMember", db.TableCenters1081753.ToList());
        }
        [HttpPost]
        public ActionResult Create(TableCenters1081753 center)
        {
            try
            {
                db.TableCenters1081753.Add(center);
                db.SaveChanges();
                return RedirectToAction("CenterDB", new { Code = center.Code });
            }
            catch(Exception ex)
            {}
            return View(center);
        }
        int pageSize = 7;
        public ActionResult CenterDB(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;
            var centers = db.TableCenters1081753.OrderBy(m => m.Code).ToList();
            var result = centers.ToPagedList(currentPage, pageSize);
            return View("../Home/CenterDB", "_LayoutMember", result);
        }
        public ActionResult FirstPage()
        {
            return View();
        }
        
        // GET: Member
        public ActionResult Index()
        {
            var centers = db.TableCenters1081753.OrderByDescending(m => m.Year).ToList();
            return View("../Home/Index", "_LayoutMember", centers);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult WishList()
        {
            string Account = User.Identity.Name;
            var wishlist = db.TableWishLists1081753.Where(m => m.User_Account == Account).ToList();
            return View(wishlist);
        }

        public ActionResult AddList(string Code)
        {
            string Account = User.Identity.Name;
            var currentList = db.TableWishLists1081753.Where(m => m.User_Account == Account && m.Code == Code).FirstOrDefault();

            if(currentList == null)
            {
                var place = db.TableCenters1081753.Where(m => m.Code == Code).FirstOrDefault();
                TableWishLists1081753 wishlist = new TableWishLists1081753();
                wishlist.User_Account = Account;
                wishlist.Code = place.Code;
                wishlist.CNName = place.CNName;
                wishlist.ENName = place.ENName;
                wishlist.Address = place.Adress;
                db.TableWishLists1081753.Add(wishlist);
            }
           

            db.SaveChanges();
            return RedirectToAction("WishList");
        }
        public ActionResult DeleteList(int wish_Id)
        {
            var wishlist = db.TableWishLists1081753.Where(m => m.Wish_Id == wish_Id).FirstOrDefault();
            db.TableWishLists1081753.Remove(wishlist);
            db.SaveChanges();
            return RedirectToAction("WishList");
        }
        
    }
}