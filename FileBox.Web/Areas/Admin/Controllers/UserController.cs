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
            //var viewUsers = Mapper.Map<IEnumerable<UserInfo>, IEnumerable<UserInfoMapModel>>(users);
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
                return RedirectToNotFoundPage;
            }
            var user = UserService.GetUserInfo((int)id);
            if (user == null)
            {
                return RedirectToNotFoundPage;
            }
            //var detailUser = Mapper.Map<UserInfo, UserInfoMapModel>(user);
            var detailUser = user.ToUserInfoMapModel();
            return View(detailUser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var user = UserService.GetUserInfo((int)id);
            if (user == null)
            {
                return RedirectToNotFoundPage;
            }
            //var roles = Mapper.Map<IEnumerable<UserRole>, IEnumerable<UserRoleMapModel>>(RoleService.GetRoleInfos());
            var roles = RoleService.GetRoleInfos().Select(r => r.ToUserRoleMapModel());
            ViewBag.Roles = new SelectList(roles, "UserRoleID", "Role", id);
            //var editUser = Mapper.Map<UserInfo, UserInfoMapModel>(user);
            var editUser = user.ToUserInfoMapModel();
            return View(editUser);
        }

        [HttpPost]
        public ActionResult Edit(UserInfoMapModel uModel)
        {
            if (ModelState.IsValid)
            {
                //var editUser = Mapper.Map<UserInfoMapModel, UserInfo>(uModel);

                var editUser = uModel.ToUserInfo();
                editUser.Password = Crypto.SHA1(editUser.Password);
                UserService.UpdateUserInfo(editUser);
                UserService.SaveUserInfo();
                return RedirectToAction("Index");
            }
            return View(uModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var user = UserService.GetUserInfo((int)id);
            if (user == null)
            {
                return RedirectToNotFoundPage;
            }
            //var deleteUser = Mapper.Map<UserInfo, UserInfoMapModel>(user);
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