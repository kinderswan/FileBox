using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileBox.Data.Infrastructure;
using FileBox.Data.Repository;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Global.Auth;
using FileBox.Web.Mappings;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {
        public HomeController(IAuthentication auth, IFilesInfoService fService, IUserInfoService uService)
        {
            Auth = auth;
            FileService = fService;
            UserService = uService;
        }

        public ActionResult Index()
        {
            if (CurrentUser != null)
            {
                ViewBag.TotalUsage = UserService.GetUserInfo(CurrentUser.UserInfoID)
                    .Files.Select(f => f.FileBytes)
                    .Sum(t => t.Length) / 1024;
                ViewBag.CurrentUserExists = true;
            }
            return View(CurrentUser);
        }

        [ChildActionOnly]
        public ActionResult FilesData(int id)
        {
            var files = FileService.GetFilesInfos().Where(f => f.UserInfoID == id).Select(t => t.ToFilesInfoMapModel());
            return PartialView("_File", files);
        }
    }
}