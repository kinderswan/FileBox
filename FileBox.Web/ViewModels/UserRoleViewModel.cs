using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class UserRoleViewModel
    {
        public int UserRoleID { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }
    }
}