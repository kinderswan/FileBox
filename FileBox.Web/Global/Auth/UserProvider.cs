using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using FileBox.Service;

namespace FileBox.Web.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIdentity userIdentity;
        public UserProvider(string email, IUserInfoService service)
        {
            userIdentity = new UserIdentity();
            userIdentity.Init(email, service);
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            return userIdentity.User.Roles.Any();
        }

        public IIdentity Identity
        {
            get { return userIdentity; }
        }

        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}