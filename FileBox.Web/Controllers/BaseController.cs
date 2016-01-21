using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Global.Auth;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IAuthentication Auth;
        protected IUserInfoService UserService;
        protected IFilesInfoService FileService;
        protected IUserRoleService RoleService;



        protected UserInfoMapModel CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

        protected RedirectResult RedirectToNotFoundPage
        {
            get { return Redirect("~/NotFoundPage"); }
        }
        protected RedirectResult RedirectToForbiddenPage
        {
            get { return Redirect("~/Forbidden"); }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            filterContext.Result = Redirect("~/Error");
        }
    }
}