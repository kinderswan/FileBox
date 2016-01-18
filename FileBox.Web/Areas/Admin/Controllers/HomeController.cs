using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileBox.Web.Global.Auth;

namespace FileBox.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}