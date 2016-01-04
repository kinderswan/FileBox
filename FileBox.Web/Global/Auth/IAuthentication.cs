using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FileBox.Model.Models;

namespace FileBox.Web.Global.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }
        UserInfo Login(string email, string password, bool isPersistent);
        UserInfo Login(string email);
        void LogOut();
        IPrincipal CurrentUser { get; }
    }
}
