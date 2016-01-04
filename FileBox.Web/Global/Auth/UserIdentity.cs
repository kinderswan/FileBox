using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using FileBox.Model.Models;
using FileBox.Service;

namespace FileBox.Web.Global.Auth
{
    public class UserIdentity : IIdentity, IUserProvider
    {
        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                return "anonym";
            }
        }

        public string AuthenticationType
        {
            get
            {
                return typeof(UserInfo).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public UserInfo User { get; set; }

        public void Init(string email, IUserInfoService service)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = service.GetUserInfo(email);
            }
        }
    }
}