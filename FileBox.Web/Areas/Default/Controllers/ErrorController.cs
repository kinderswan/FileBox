using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class ErrorController : DefaultController
    {
        // GET: Default/Forbidden
        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }

        public ActionResult NotFoundPage()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult TooLongFile()
        {
            return View();
        }
    }
}