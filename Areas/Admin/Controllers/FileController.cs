using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Web.Global.Auth;
using FileBox.Web.Global.FileWork;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Admin.Controllers
{
    public class FileController : AdminController
    {
        private readonly IFileOps _fileOperations;
        public FileController() { }

        public FileController(IFilesInfoService fService, IUserInfoService uService, IFileOps fOps)
        {
            FileService = fService;
            UserService = uService;
            _fileOperations = fOps;
        }
        // GET: Admin/File
        public ActionResult Index(int? id)
        {
            var files = FileService.GetFilesInfos();
            if (id != null)
            {
                files = files.Where(f => f.UserInfoID == id);
            }
            var viewFiles = Mapper.Map<IEnumerable<FilesInfo>, IEnumerable<FilesInfoViewModel>>(files);
            return View(viewFiles);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var file = FileService.GetFileInfo((int)id);
            if (file == null)
            {
                return RedirectToNotFoundPage;
            }
            ViewBag.UserLogin = UserService.GetUserInfo(file.UserInfoID).Login;

            return View(Mapper.Map<FilesInfo, FilesInfoViewModel>(file));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var file = FileService.GetFileInfo((int)id);
            if (file == null)
            {
                return RedirectToNotFoundPage;
            }
            var editFile = Mapper.Map<FilesInfo, FilesInfoAdminModel>(file);
            TempData["OldFileModel"] = editFile;
            return View(editFile);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(FilesInfoAdminModel fModel)
        {
            if (ModelState.IsValid)
            {
                var editFile = Mapper.Map<FilesInfoAdminModel, FilesInfo>(fModel);
                FileService.UpdateFileInfo(editFile);
                FileService.SaveFileInfo();
                await _fileOperations.ChangeFileNameAsync((FilesInfoAdminModel)TempData["OldFileModel"], fModel);
                return RedirectToAction("Index");
            }
            return View(fModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var file = FileService.GetFileInfo((int)id);
            if (file == null)
            {
                return RedirectToNotFoundPage;
            }
            var deleteFile = Mapper.Map<FilesInfo, FilesInfoAdminModel>(file);
            TempData["DeleteFile"] = deleteFile;
            return View(deleteFile);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FileService.DeleteFileInfo(id);
            FileService.SaveFileInfo();
            await _fileOperations.DeleteFileAsync((FilesInfoAdminModel)TempData["DeleteFile"]);
            return RedirectToAction("Index");
        }
    }
}