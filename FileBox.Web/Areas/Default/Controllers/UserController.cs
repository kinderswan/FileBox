using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.Global.Auth;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class UserController : DefaultController
    {

        public UserController() { }

        public UserController(IUserInfoService uService, IUserRoleService rService, IAuthentication auth)
        {
            UserService = uService;
            RoleService = rService;
            Auth = auth;
        }

        // GET: Default/User
        public ActionResult Index()
        {
            return RedirectToAction("Register");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new UserInfoFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserInfoFormModel uFormModel)
        {
            if (UserService.GetUserInfos().Any(p => p.Login == uFormModel.Login))
            {
                ModelState.AddModelError("Login", "Пользователь с таким логином уже существует");
            }
            if (UserService.GetUserInfos().Any(p => p.Email == uFormModel.Email))
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже существует");
            }
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<UserInfoFormModel, UserInfo>(uFormModel);
                user.Roles.Add(RoleService.GetRoleInfo("User"));

                UserService.CreateUserInfo(user);
                UserService.SaveUserInfo();

                return RedirectToAction("Index", "Home");

            }
            return View(new UserInfoFormModel());
        }

        public ActionResult Info(string email)
        {
            var user = UserService.GetUserInfo(email);
            ViewBag.IsAdmin = Auth.CurrentUser.IsInRole("Admin");
            return View(Mapper.Map<UserInfo, UserInfoViewModel>(user));
        }
    }
}