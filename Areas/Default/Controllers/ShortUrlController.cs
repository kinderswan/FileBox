using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileBox.Service;

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
                return Content("<script language='javascript' type='text/javascript'>alert('File not found!');</script>");
            }
            if (fInfo.FileAccess == false)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You have no permissions to download that file!');</script>");
            }
            var uInfo = UserService.GetUserInfo(fInfo.UserInfoID);
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", uInfo.DirectoryPath, fInfo.FileName + fInfo.Extension);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = String.Format("{0}{1}", fInfo.FileName, fInfo.Extension);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}