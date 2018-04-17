using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAuthSystem.Models
{
    [Table("tbl_Posts")]
    public class PostSetup
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