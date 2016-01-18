using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class UserRoleFormModel
    {
        public int UserRoleID { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }
        public int UserInfoID { get; set; }
    }
}