using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBox.Web.ViewModels
{
    public class UserFormModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}