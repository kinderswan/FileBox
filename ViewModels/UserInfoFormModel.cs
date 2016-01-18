using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class UserInfoFormModel
    {
        [MaxLength(20, ErrorMessage = "Too long name")]
        public string UserName { get; set; }

        [MaxLength(50, ErrorMessage = "Too long surname")]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "Login can't be empty")]
        [MaxLength(20, ErrorMessage = "Login length must be less than 15 symbols")]
        [MinLength(5, ErrorMessage = "Login length must be at least 5 symbols")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }
    }
}