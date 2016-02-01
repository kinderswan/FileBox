using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class FilesInfoUploadModel
    {
        [Required(ErrorMessage = "Choose file to download")]
        public HttpPostedFileBase File { get; set; }
        public bool FileAccess { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}