﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using FileBox.Service;

namespace FileBox.Web.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        private readonly UserIdentity _userIdentity;
        public UserProvider(string email, IUserInfoService service)
        {
            _userIdentity = new UserIdentity();
            _userIdentity.Init(email, service);
        }

        public bool IsInRole(string role)
        {
            if (_userIdentity.User == null)
            {
                return false;
            }
            return _userIdentity.User.Roles.Any(item => item.Role == role);
        }

        public IIdentity Identity
        {
            get { return _userIdentity; }
        }

        public override string ToString()
        {
            return _userIdentity.Name;
        }
    }
}