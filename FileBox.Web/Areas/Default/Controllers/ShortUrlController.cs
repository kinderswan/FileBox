using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileBox.Service;
using FileBox.Service.Interfaces;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class ShortUrlController : DefaultController
    {
        public ShortUrlController() { }

        public ShortUrlController(IFilesInfoService fService, IUserInfoService uService)
        {
            FileService = fService;
            UserService = uService;
        }
        // GET: Default/ShortUrl
        public ActionResult Index(string name)
        {
            var fInfo = FileService.GetFileInfo(name);
            if (fInfo == null)
            {
                return RedirectToNotFoundPage;
            }
            if (fInfo.FileAccess == false)
            {
                return RedirectToForbiddenPage;
            }

            byte[] fileBytes = fInfo.FileBytes;
            var fileName = String.Format("{0}{1}", fInfo.FileName, fInfo.Extension);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}