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

namespace FileBox.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        public UserController() { }

        public UserController(IUserInfoService uService, IAuthentication auth)
        {
            UserService = uService;
            Auth = auth;
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            var users = UserService.GetUserInfos();
            var viewUsers = Mapper.Map<IEnumerable<UserInfo>, IEnumerable<UserInfoViewModel>>(users);
            return View(viewUsers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var user = UserService.GetUserInfo((int) id);
            if (user == null)
            {
                return RedirectToNotFoundPage;
            }
            return View(Mapper.Map<UserInfo, UserInfoViewModel>(user));
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var user = UserService.GetUserInfo((int) id);
            if (user == null)
            {
                return RedirectToNotFoundPage;
            }
            return View(Mapper.Map<UserInfo, UserInfoAdminModel>(user));
        }

        [HttpPost]
        public ActionResult Edit(UserInfoAdminModel uModel)
        {
            if (ModelState.IsValid)
            {
                var editUser = Mapper.Map<UserInfoAdminModel, UserInfo>(uModel);
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
            var user = UserService.GetUserInfo((int) id);
            if (user == null)
            {
                return RedirectToNotFoundPage;
            }
            return View(Mapper.Map<UserInfo, UserInfoViewModel>(user));
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