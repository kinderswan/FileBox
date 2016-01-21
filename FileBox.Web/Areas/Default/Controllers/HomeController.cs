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

                ViewBag.Files = TempData["SearchFiles"] ?? CurrentUser.Files;
            }
            return View(CurrentUser);
        }
    }
}