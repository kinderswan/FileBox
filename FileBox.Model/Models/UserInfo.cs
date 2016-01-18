using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBox.Model.Models
{
    public class UserInfo
    {
        public int UserInfoID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? WasCreated { get; set;}
        public string DirectoryPath { get; set; }

        public virtual ICollection<FilesInfo> Files { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; } 


        public UserInfo()
        {
            WasCreated = DateTime.Now;
            DirectoryPath = Guid.NewGuid().ToString();
        }
    }
}
