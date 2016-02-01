using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Global.Auth;
using FileBox.Web.Mappings;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        public UserController() { }

        public UserController(IUserInfoService uService, IUserRoleService rService)
        {
            UserService = uService;
            RoleService = rService;
        }
        public ActionResult Index()
        {
            var users = UserService.GetUserInfos();
            var viewUsers = users.Select(u => u.ToUserInfoMapModel());
            return View(viewUsers);
        }

        public ActionResult Create()
        {
            var roles = RoleService.GetRoleInfos().Select(r => r.ToUserRoleMapModel());
            ViewBag.Roles = new SelectList(roles, "UserRoleID", "Role");
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfoMapModel uModel)
        {
            if (ModelState.IsValid)
            {
                if (UserService.GetUserInfos().Any(p => p.Login == uModel.Login))
                {
                    ModelState.AddModelError("Login", "Sorry, user with the same login is already exists");
                }
                if (UserService.GetUserInfos().Any(p => p.Email == uModel.Email))
                {
                    ModelState.AddModelError("Email", "Sorry, user with the same email is already exists");
                }
                var user = uModel.ToUserInfo();
                user.Password = Crypto.SHA1(user.Password);
                UserService.CreateUserInfo(user);
                UserService.SaveUserInfo();
                return RedirectToAction("Index");
            }
            return View(uModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var user = UserService.GetUserInfo((int)id);
            if (user == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var detailUser = user.ToUserInfoMapModel();
            return View(detailUser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var user = UserService.GetUserInfo((int)id);
            if (user == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var roles = RoleService.GetRoleInfos().Select(r => r.ToUserRoleMapModel());
            ViewBag.Roles = new SelectList(roles, "UserRoleID", "Role", id);
            var editUser = user.ToUserInfoMapModel();
            return View(editUser);
        }

        [HttpPost]
        public ActionResult Edit(UserInfoMapModel uModel)
        {
            var userLoginBeforeSave = UserService.GetUserInfo(uModel.UserInfoID).Login;
            if (UserService.GetUserInfos()
                    .Where(u => u.Login != userLoginBeforeSave)
                    .Any(p => p.Login == uModel.Login))
            {
                ModelState.AddModelError("Login", "Sorry, user with the same login is already exists");
            }
            if (ModelState.IsValid)
            {
                var editUser = uModel.ToUserInfo();
                UserService.UpdateUserInfo(editUser);
                UserService.SaveUserInfo();
                return RedirectToAction("Index");
            }
            var roles = RoleService.GetRoleInfos().Select(r => r.ToUserRoleMapModel());
            ViewBag.Roles = new SelectList(roles, "UserRoleID", "Role", uModel.UserInfoID);
            return View(uModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var user = UserService.GetUserInfo((int)id);
            if (user == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var deleteUser = user.ToUserInfoMapModel();
            return View(deleteUser);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserService.DeleteUserInfo(id);
            UserService.SaveUserInfo();
            return RedirectToAction("Index");
        }

    }

}