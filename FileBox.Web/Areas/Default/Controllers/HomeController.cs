using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FileBox.Data.Infrastructure;
using FileBox.Data.Repository;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.Global.Auth;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {

        public HomeController(IAuthentication auth, IFilesInfoService fService)
        {
            Auth = auth;
            FileService = fService;
        }
        public ActionResult Index()
        {
            if (CurrentUser != null)
            {

                ViewBag.CurrentUser = CurrentUser;
                ViewBag.ShortUrl = System.Web.HttpContext
                    .Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/_";

                if (TempData["SearchValues"] != null)
                {
                    ViewBag.Files = (IEnumerable<FilesInfoViewModel>)TempData["SearchValues"];
                }
                else
                {
                    ViewBag.Files =
                        Mapper.Map<IEnumerable<FilesInfoAdminModel>, IEnumerable<FilesInfoViewModel>>(CurrentUser.Files);

                }
            }
            return View(Mapper.Map<UserInfoAdminModel, UserInfoViewModel>(CurrentUser));
        }
    }
}