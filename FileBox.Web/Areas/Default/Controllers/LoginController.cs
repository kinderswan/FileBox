using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FileBox.Data.Repository;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Global.Auth;
using FileBox.Web.Mappings;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class LoginController : DefaultController
    {
        public LoginController(IAuthentication auth, IUserInfoService uService)
        {
            Auth = auth;
            UserService = uService;
        }
        // GET: Default/Login
        public ActionResult Index()
        {
            return View(new UserInfoRegisterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserInfoRegisterModel userRegisterModel, bool isRemember = false)
        {
            ModelState.Remove("Login");
            //var userData = Mapper.Map<UserInfoRegisterModel, UserInfo>(userRegisterModel);
            var userData = userRegisterModel.ToUserInfo();
            
            if (ModelState.IsValid)
            {
                if (UserService.GetUserInfos().All(u => u.Email != userRegisterModel.Email))
                {
                    ModelState["Email"].Errors.Add("Input email is not registered in system");
                }
                if (userData.Password == Crypto.SHA1(userRegisterModel.Password))
                {
                    var user = Auth.Login(userData.Email, userData.Password, isRemember);
                    if (user != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState["Password"].Errors.Add("Password does not match");
            }
            return View(new UserInfoRegisterModel());
        }
        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}