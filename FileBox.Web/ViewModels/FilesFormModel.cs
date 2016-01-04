using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class FilesFormModel
    {
        public HttpPostedFileBase File { get; set; }
        public bool FileAccess { get; set; }
        public int UserID { get; set; }
    }
}