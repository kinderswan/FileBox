using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class FilesInfoAdminModel
    {
        public int FilesInfoID { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string ShortUrl { get; set; }
        public bool FileAccess { get; set; }
        public DateTime? WasCreated { get; set; }
        public int UserInfoID { get; set; }
    }
}