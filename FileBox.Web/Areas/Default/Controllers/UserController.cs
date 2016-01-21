using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Global.Auth;
using FileBox.Web.Mappings;
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
            return View(new UserInfoRegisterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserInfoRegisterModel uRegisterModel)
        {
            if (UserService.GetUserInfos().Any(p => p.Login == uRegisterModel.Login))
            {
                ModelState.AddModelError("Login", "Пользователь с таким логином уже существует");
            }
            if (UserService.GetUserInfos().Any(p => p.Email == uRegisterModel.Email))
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже существует");
            }
            if (ModelState.IsValid)
            {
                //var user = Mapper.Map<UserInfoRegisterModel, UserInfo>(uRegisterModel);
                var user = uRegisterModel.ToUserInfo();
                user.UserRoleID = 2; //User default register
                UserService.CreateUserInfo(user);
                UserService.SaveUserInfo();
                return RedirectToAction("Index", "Home");

            }
            return View(new UserInfoRegisterModel());
        }

        public ActionResult Info(string email)
        {
            var user = UserService.GetUserInfo(email);
            ViewBag.IsAdmin = Auth.CurrentUser.IsInRole("Admin");
            //var infoUser = Mapper.Map<UserInfo, UserInfoMapModel>(user);
            var infoUser = user.ToUserInfoMapModel();
            return View(infoUser);
        }
    }
}