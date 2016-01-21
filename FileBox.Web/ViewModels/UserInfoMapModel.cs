using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class UserInfoMapModel
    {
        [Required]
        public int UserInfoID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Login can't be empty")]
        [MaxLength(20, ErrorMessage = "Login length must be less than 15 symbols")]
        [MinLength(5, ErrorMessage = "Login length must be at least 5 symbols")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }

        public DateTime? WasCreated { get; set; }

        public ICollection<FilesInfoMapModel> Files { get; set; }
        public UserRoleMapModel UserRole { get; set; }
        [Required]
        public int UserRoleID { get; set; }
    }
}