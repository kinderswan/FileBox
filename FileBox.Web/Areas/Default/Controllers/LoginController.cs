using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using FileBox.Data.Repository;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.Global.Auth;
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
            return View(new UserInfoFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserInfoFormModel userFormModel, bool isRemember = false)
        {

            UserInfo userData = Mapper.Map<UserInfoFormModel, UserInfo>(userFormModel);
            ModelState.Remove("Login");
            if (ModelState.IsValid)
            {
                if (UserService.GetUserInfos().All(u => u.Email != userFormModel.Email))
                {
                    ModelState["Email"].Errors.Add("Input email is not registered in system");
                }
                var user = Auth.Login(userData.Email, userData.Password, isRemember);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add("Password does not match");
            }
            return View(new UserInfoFormModel());
        }
        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}