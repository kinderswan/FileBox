using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.Global.Auth;
using FileBox.Web.Global.FileWork;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Default.Controllers
{
    public class FileController : DefaultController
    {
        private readonly IFileOps _fileOps; 
        public FileController() { }

        public FileController(IFilesInfoService fService, IFileOps fOps, IAuthentication auth)
        {
            FileService = fService;
            _fileOps = fOps;
            Auth = auth;
        }
        // GET: Default/File
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(FilesInfoFormModel fileModel)
        {
            if (fileModel != null && fileModel.File != null)
            {
                var file = Mapper.Map<FilesInfoFormModel, FilesInfo>(fileModel);
                if (
                    FileService.GetFilesInfos()
                        .Any(item => item.FileName == file.FileName && item.Extension == file.Extension))
                {
                    file.FileName = "Copy_" + file.FileName;
                }
                FileService.CreateFileInfo(file);
                FileService.SaveFileInfo();

                string filename = Path.GetFileName(fileModel.File.FileName);
                var savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", CurrentUser.DirectoryPath);
                string saveLocation = savePath + "\\" + filename;
                Directory.CreateDirectory(savePath);
                fileModel.File.SaveAs(saveLocation);

            }
            return RedirectToAction("Index", "Home");
        }

        public FileResult Download(FilesInfo fInfo)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", CurrentUser.DirectoryPath, fInfo.FileName + fInfo.Extension);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = String.Format("{0}{1}", fInfo.FileName, fInfo.Extension);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult Delete(FilesInfo fInfo)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", CurrentUser.DirectoryPath, fInfo.FileName + fInfo.Extension);
            FileService.DeleteFileInfo(fInfo.FilesInfoID);
            System.IO.File.Delete(filePath);
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

            var viewFiles = files.Concat(extNames).ToList();
            TempData["SearchValues"] = Mapper.Map<IEnumerable<FilesInfo>, IEnumerable<FilesInfoViewModel>>(viewFiles);

            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult EditFile(int id)
        {
            var viewFile = Mapper.Map<FilesInfo, FilesInfoAdminModel>(FileService.GetFileInfo(id));
            TempData["EditFile"] = viewFile;
            return PartialView("EditFile", viewFile);
        }

        [HttpPost]
        public async Task<ActionResult> EditFile(FilesInfoAdminModel fModel)
        {
            if (ModelState.IsValid)
            {
                var editFile = Mapper.Map<FilesInfoAdminModel, FilesInfo>(fModel);
                FileService.UpdateFileInfo(editFile);
                FileService.SaveFileInfo();
                await _fileOps.ChangeFileNameAsync((FilesInfoAdminModel)TempData["EditFile"], fModel);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


    }
}