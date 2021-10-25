//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class TableCenters1081753
    {
        [DisplayName("場域代號")]
        public string Code { get; set; }
        [DisplayName("場域中文名稱")]
        public string CNName { get; set; }
        [DisplayName("場域英文名稱")]
        public string ENName { get; set; }
        [DisplayName("場域地址")]
        public string Adress { get; set; }
        [DisplayName("場域年分")]
        public Nullable<int> Year { get; set; }
        [DisplayName("場域種類")]
        public string Genre { get; set; }
        [DisplayName("場域圖片")]
        public string Img { get; set; }
        [DisplayName("場域電話")]
        public string phone { get; set; }
        [DisplayName("場域簡介")]
        public string descript { get; set; }
    }
}