using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Global.Auth;
using FileBox.Web.Mappings;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class FileController : DefaultController
    {
        public FileController() { }

        public FileController(IFilesInfoService fService, IAuthentication auth)
        {
            FileService = fService;
            Auth = auth;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(FilesInfoUploadModel fileModel)
        {
            if (ModelState.IsValid && Request.Files[0] != null)
            {
                //var file = Mapper.Map<FilesInfoUploadModel, FilesInfo>(fileModel);
                var file = fileModel.ToFilesInfo();

                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    file.FileBytes = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }

                FileService.CreateFileInfo(file);
                FileService.SaveFileInfo();
            }

            return RedirectToAction("Index", "Home");
        }

        public FileResult Download(int id)
        {
            var file = FileService.GetFileInfo(id);
            byte[] fileBytes = file.FileBytes;
            var fileName = String.Format("{0}{1}", file.FileName, file.Extension);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult Delete(int id)
        {
            FileService.DeleteFileInfo(id);
            FileService.SaveFileInfo();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Search(string findFiles)
        {
            if (string.IsNullOrEmpty(findFiles))
            {
                return RedirectToAction("Index", "Home");
            }

            var files = FileService.GetFilesInfos()
                    .Where(f => f.UserInfoID == CurrentUser.UserInfoID)
                    .Where(f => f.FileName.ToLower().Contains(findFiles)).ToList();

            var extNames = FileService.GetFilesInfos()
                    .Where(f => f.UserInfoID == CurrentUser.UserInfoID)
                    .Where(f => f.Extension.ToLower().Contains(findFiles)).ToList();

            var viewFiles = files.Concat(extNames).Select(f => f.ToFilesInfoMapModel()).ToList();
            //TempData["SearchFiles"] = Mapper.Map<IEnumerable<FilesInfo>, IEnumerable<FilesInfoMapModel>>(viewFiles);
            TempData["SearchFiles"] = viewFiles;
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult EditFile(int id)
        {
            //var viewFile = Mapper.Map<FilesInfo, FilesInfoMapModel>(FileService.GetFileInfo(id));
            var viewFile = FileService.GetFileInfo(id).ToFilesInfoMapModel();
            return PartialView("EditFile", viewFile);
        }

        [HttpPost]
        public ActionResult EditFile(int? id, string newName, bool? fAccess)
        {
            if (ModelState.IsValid)
            {
                var editFile = FileService.GetFileInfo((int)id);

                editFile.FileName = newName;
                editFile.FileAccess = (bool)fAccess;

                FileService.UpdateFileInfo(editFile);
                FileService.SaveFileInfo();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


    }
}