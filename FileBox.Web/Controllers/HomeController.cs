using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FileBox.Data.Infrastructure;
using FileBox.Data.Repository;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilesInfoService _filesInfoService;

        public HomeController() { }
        public HomeController(IFilesInfoService filesInfoService)
        {
            this._filesInfoService = filesInfoService;
        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
            IEnumerable<FilesInfo> files = _filesInfoService.GetFilesInfos();
            var viewModelFiles = Mapper.Map<IEnumerable<FilesInfo>, IEnumerable<FilesInfoViewModel>>(files);
            return View(viewModelFiles);
        }
    }
}