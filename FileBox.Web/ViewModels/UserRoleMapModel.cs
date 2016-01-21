using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class UserRoleMapModel
    {
        [Required]
        public int UserRoleID { get; set; }
        [Required]
        public string Role { get; set; }
        public string RoleDescription { get; set; }

        public ICollection<UserInfoMapModel> Users { get; set; }
    }
}