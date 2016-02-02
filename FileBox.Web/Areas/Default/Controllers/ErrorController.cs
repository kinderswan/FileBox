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
            ViewBag.ErrorCode = "403 Forbidden";
            ViewBag.ErrorMessage = "Sorry, you don't have permission to access the requested page!";
            return View("Error");
        }

        public ActionResult NotFoundPage()
        {
            Response.StatusCode = 404;
            ViewBag.ErrorCode = "404 Page Not Found";
            ViewBag.ErrorMessage = "Sorry, an error has occured, requested page not found!";
            return View("Error");
        }

        public ActionResult TooLongFile()
        {
            ViewBag.ErrorCode = "404.13 Too long file";
            ViewBag.ErrorMessage = "Sorry, you can not upload files with length greater than 30MB!";
            return View("Error");
        }
    }
}