using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using AutoMapper;
using FileBox.Model.Models;
using FileBox.Service;
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
                return typeof(UserInfo).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public UserInfoAdminModel User { get; set; }

        public void Init(string email, IUserInfoService service)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = Mapper.Map<UserInfo, UserInfoAdminModel>(service.GetUserInfo(email));
            }
        }
    }
}