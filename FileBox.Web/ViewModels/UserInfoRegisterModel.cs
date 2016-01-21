using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FileBox.Web.ViewModels
{
    public class UserInfoRegisterModel
    {
        [Required(ErrorMessage = "Login can't be empty")]
        [MaxLength(20, ErrorMessage = "Login length must be less than 15 symbols")]
        [MinLength(5, ErrorMessage = "Login length must be at least 5 symbols")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }

        [Required]
        public int UserInfoID { get; set; }
    }
}