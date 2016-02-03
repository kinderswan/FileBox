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
                ModelState.AddModelError("Login", "Sorry, user with the same login is already exists");
            }
            if (UserService.GetUserInfos().Any(p => p.Email == uRegisterModel.Email))
            {
                ModelState.AddModelError("Email", "Sorry, user with the same email is already exists");
            }
            if (ModelState.IsValid)
            {
                var user = uRegisterModel.ToUserInfo();
                user.UserRoleID = 2; //User default register
                UserService.CreateUserInfo(user);
                UserService.SaveUserInfo();
                TempData["RegYes"] = true;
                return RedirectToAction("Index", "Login");
            }
            return View(new UserInfoRegisterModel());
        }

        public ActionResult Info()
        {
            ViewBag.IsAdmin = Auth.CurrentUser.IsInRole("Admin");
            return View(CurrentUser);
        }


        public ActionResult Edit()
        {
            return View(CurrentUser);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditUser(UserInfoMapModel uModel)
        {
            if (UserService.GetUserInfos(u => u.Login != CurrentUser.Login)
                    .Any(p => p.Login == uModel.Login))
            {
                ModelState.AddModelError("Login", "Sorry, user with the same login is already exists");
            }
            if (ModelState.IsValid)
            {
                
                var user = uModel.ToUserInfo();
                UserService.UpdateUserInfo(user);
                UserService.SaveUserInfo();
                return RedirectToAction("Info", "User");
            }
            return View(uModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(404);
            UserService.DeleteUserInfo((int)id);
            UserService.SaveUserInfo();
            return RedirectToAction("Index", "Home");

        }
    }
}