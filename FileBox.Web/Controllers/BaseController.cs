using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.Global.Auth;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected static string ErrorPage = "~/Error";
        protected static string NotFoundPage = "~/NotFoundPage";
        protected static string LoginPage = "~/Login";
        protected IAuthentication Auth;
        protected IUnitOfWork UnitOfWork;
        protected IUserInfoService UserService;
        protected IFilesInfoService FileService;
        protected IUserRoleService RoleService;

        protected UserInfoAdminModel CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

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