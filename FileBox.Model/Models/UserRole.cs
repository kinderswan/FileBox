using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBox.Model.Models
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }

        public int UserInfoID { get; set; }
        public UserInfo UserInfo { get; set; } 

        public UserRole() { }
    }
}
