using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FileBox.Model.Models;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {
        public HomeController():base() { }
        // GET: Default/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}