using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.Global.Auth;

namespace FileBox.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public IUserInfoService UserService { get; set; }
        public IFilesInfoService FilesInfoService { get; set; }
        public IUserRoleService RoleService { get; set; }
        public IAuthentication Auth { get; set; }

        public UserInfo CurrentUser
        {
            get { return ((IUserProvider)Auth.CurrentUser.Identity).User; }
        }

        protected static string ErrorPage = "~/Error";
        protected static string NotFoundPage = "~/NotFoundPage";
        protected static string LoginPage = "~/Login";

        public RedirectResult RedirectToNotFoundPage
        {
            get { return Redirect(NotFoundPage); }
        }

        public RedirectResult RedirectToLoginPage
        {
            get { return Redirect(LoginPage); }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            filterContext.Result = Redirect(ErrorPage);
        }
    }
}