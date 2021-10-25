using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using prjFinalProject.Models;
using System.Web.Security;
namespace prjFinalProject.Controllers
{
    public class HomeController : Controller
    {
        dbArtsCenterEntities db = new dbArtsCenterEntities();

        public ActionResult Edit(string Code)
        {
            var centers = db.TableCenters1081753.Where(m => m.Code == Code).FirstOrDefault();
            return View(centers);
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
            return View(centers);
        }

        int pageSize = 7;
        public ActionResult CenterDB(int page=1)
        {
            int currentPage = page < 1 ? 1 : page;
            var centers = db.TableCenters1081753.OrderBy(m => m.Code).ToList();
            var result = centers.ToPagedList(currentPage, pageSize);
            return View(result);
        }

        // GET: Homw
        public ActionResult FirstPage()
        {
            return View();
        }

        public ActionResult Index()
        {
            var centers = db.TableCenters1081753.OrderByDescending(m => m.Year).ToList();
            return View(centers);
        }

        

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User_Account, string User_Pwd)
        {
            var member = db.TableMembers1081753.Where(m => m.User_Account == User_Account && m.User_Pwd == User_Pwd).FirstOrDefault();

            if(member == null)
            {
                ViewBag.Message = "帳密錯誤，請檢查是否錯誤！";
                ViewBag.color = "red";
                return View();
            }
            Session["Welcome"] = member.User_Name + "歡迎登入";
            FormsAuthentication.RedirectFromLoginPage(User_Account, true);
            return RedirectToAction("Index", "Member");
        }

        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(TableMembers1081753 pMember)
        {
            if(ModelState.IsValid == false)
            {
                return View();
            }
            var member = db.TableMembers1081753.Where(m => m.User_Account == pMember.User_Account).FirstOrDefault();

            if(member == null)
            {
                db.TableMembers1081753.Add(pMember);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Message = "此帳號已有人使用，註冊失敗";
            return View();

        }

        
    }
}