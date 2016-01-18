using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class FilesInfoFormModel
    {
        [Required(ErrorMessage = "Choose file to download")]
        public HttpPostedFileBase File { get; set; }
        public bool FileAccess { get; set; }
        public int UserID { get; set; }
    }
}