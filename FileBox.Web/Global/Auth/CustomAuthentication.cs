using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using AutoMapper;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Global.Auth
{
    public class CustomAuthentication : IAuthentication
    {
        private readonly IUserInfoService _userInfoService;
        private const string CookieName = "__AUTH_COOKIE";

        private IPrincipal _currentUser;

        public HttpContext HttpContext { get; set; }

        public UserInfoService UserService { get; set; }

        public CustomAuthentication(IUserInfoService service)
        {
            _userInfoService = service;
        }

        public UserInfoAdminModel Login(string email, string password, bool isPersistent)
        {
            UserInfoAdminModel retUser = Mapper.Map<UserInfo, UserInfoAdminModel>(_userInfoService.GetUserInfo(email, password));
            if (retUser != null)
            {
                CreateCookie(email, isPersistent);
            }
            return retUser;
        }

        public UserInfoAdminModel Login(string email)
        {
            UserInfoAdminModel retUser = Mapper.Map<UserInfo, UserInfoAdminModel>(_userInfoService.GetUserInfo(email));
            if (retUser != null)
            {
                CreateCookie(email);
            }
            return retUser;
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
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
            var authCookie = new HttpCookie(CookieName)
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
                    HttpCookie authCookie = HttpContext.Request.Cookies.Get(CookieName);
                    if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                    {
                        var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                        _currentUser = new UserProvider(ticket.Name, _userInfoService);
                    }
                    else
                    {
                        _currentUser = new UserProvider(null, null);
                    }
                }
                catch
                {
                    _currentUser = new UserProvider(null, null);
                }

            }
            return _currentUser;
        }
    }
}