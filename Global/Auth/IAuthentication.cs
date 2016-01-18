﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FileBox.Model.Models;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Global.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }
        UserInfoAdminModel Login(string email, string password, bool isPersistent);
        UserInfoAdminModel Login(string email);
        void LogOut();
        IPrincipal CurrentUser { get; }
    }
}