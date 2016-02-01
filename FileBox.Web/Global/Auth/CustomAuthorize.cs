using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FileBox.Service;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace FileBox.Web.Global.Auth
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly IAuthentication _auth;

        public CustomAuthorizeAttribute()
        {
            _auth = DependencyResolver.Current.GetService<IAuthentication>();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (_auth.CurrentUser.Identity.IsAuthenticated && _auth.CurrentUser.IsInRole(Roles))
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult(@"~/Error/Forbidden");
            }
        }
    }
}