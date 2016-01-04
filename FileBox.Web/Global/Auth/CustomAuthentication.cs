using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using FileBox.Model.Models;
using FileBox.Service;

namespace FileBox.Web.Global.Auth
{
    public class CustomAuthentication : IAuthentication
    {

        private const string cookieName = "__AUTH_COOKIE";

        private IPrincipal _currentUser;

        public HttpContext HttpContext { get; set; }

        public UserInfoService UserService { get; set; }

        public UserInfo Login(string email, string password, bool isPersistent)
        {
            UserInfo retUser = UserService.GetUserInfo(email, password);
            if (retUser != null)
            {
                CreateCookie(email, isPersistent);
            }
            return retUser;
        }

        public UserInfo Login(string email)
        {
            UserInfo retUser = UserService.GetUserInfo(email);
            if (retUser != null)
            {
                CreateCookie(email);
            }
            return retUser;
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[cookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        public IPrincipal CurrentUser
        {
            get { return CurrUser(); }
        }

        private void CreateCookie(string email, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(1, email, DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout), isPersistent, string.Empty,
                FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(cookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(authCookie);
        }

        private IPrincipal CurrUser()
        {
            if (_currentUser == null)
            {
                try
                {
                    HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
                    if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                    {
                        var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                        _currentUser = new UserProvider(ticket.Name, UserService);
                    }
                    else
                    {
                        _currentUser = new UserProvider(null, null);
                    }
                }
                catch (Exception ex)
                {
                    _currentUser = new UserProvider(null, null);
                }

            }
            return _currentUser;
        }
    }
}