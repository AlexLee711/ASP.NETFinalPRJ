
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class TableMembers1081753
    {

        public int User_Id { get; set; }
        [DisplayName("帳號")]
        [Required]
        public string User_Account { get; set; }
        [DisplayName("密碼")]
        [Required]
        public string User_Pwd { get; set; }
        [DisplayName("姓名")]
        [Required]
        public string User_Name { get; set; }
        [DisplayName("電子信箱")]
        [Required]
        [EmailAddress]
        public string User_Email { get; set; }
        [DisplayName("地址")]
        [Required]
        public string User_Address { get; set; }
    }
}