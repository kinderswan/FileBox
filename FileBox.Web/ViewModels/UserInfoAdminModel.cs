using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class UserInfoAdminModel
    {
        public int UserInfoID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? WasCreated { get; set; }
        public string DirectoryPath { get; set; }
        public List<FilesInfoAdminModel> Files { get; set; }
        public List<UserRoleFormModel> Roles { get; set; }
    }
}