using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileBox.Model.Models;

namespace FileBox.Web.ViewModels
{
    public class FilesInfoViewModel
    {
        public int FilesInfoID { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string ShortUrl { get; set; }
        public bool IsDirectory { get; set; }
        public bool FileAccess { get; set; }
        public DateTime? WasCreated { get; set; }
        public int UsrID { get; set; }
    }
}