using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileBox.Model.Models;

namespace FileBox.Web.ViewModels
{
    public class UserInfoViewModel
    {
        public int UserInfoID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public DateTime? WasCreated { get; set; }
        public string DirectoryPath { get; set; }
        public List<FilesInfo> Files { get; set; } 
    }
}