using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Mappings;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Global.Auth
{
    public class UserIdentity : IIdentity, IUserProvider
    {
        public string Name
        {
            get
            {
                return User != null ? User.Email : "anonym";
            }
        }

        public string AuthenticationType
        {
            get
            {
                return typeof(UserInfoMapModel).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public UserInfoMapModel User { get; set; }

        public void Init(string email, IUserInfoService service)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = service.GetUserInfo(email).ToUserInfoMapModel();
            }
        }
    }
}