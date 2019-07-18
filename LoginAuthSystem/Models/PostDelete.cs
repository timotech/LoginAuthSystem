using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAuthSystem.Models
{
    [Table("tbl_PostDelete")]
    public class PostDelete
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string PicPath { get; set; }
        public DateTime DateAdded { get; set; }
        [NotMapped]
        public HttpPostedFileBase fleUploadImage { get; set; }
    }
}