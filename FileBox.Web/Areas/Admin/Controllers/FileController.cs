﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Global.Auth;
using FileBox.Web.Mappings;
using FileBox.Web.ViewModels;
using WebGrease.Css.Extensions;

namespace FileBox.Web.Areas.Admin.Controllers
{
    public class FileController : AdminController
    {
        public FileController() { }

        public FileController(IFilesInfoService fService, IUserInfoService uService)
        {
            FileService = fService;
            UserService = uService;
        }

        public ActionResult Index(int? id)
        {
            var files = FileService.GetFilesInfos();
            if (id != null)
            {
                files = files.Where(f => f.UserInfoID == id);
            }
            var viewFiles = files.Select(t => t.ToFilesInfoMapModel());
            return View(viewFiles);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var file = FileService.GetFileInfo((int)id);
            if (file == null)
            {
                return new HttpStatusCodeResult(404);
            }

            ViewBag.UserLogin = file.UserInfo.Login;
            var detailFiles = file.ToFilesInfoMapModel();
            return View(detailFiles);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var file = FileService.GetFileInfo((int)id);
            if (file == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var editFile = file.ToFilesInfoMapModel();
            return View(editFile);
        }

        [HttpPost]
        public ActionResult Edit(int id, string newName, bool fAccess)
        {
            if (ModelState.IsValid)
            {
                var editFile = FileService.GetFileInfo(id);

                editFile.FileName = newName;
                editFile.FileAccess = fAccess;

                FileService.UpdateFileInfo(editFile);
                FileService.SaveFileInfo();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", "File", new { id });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var file = FileService.GetFileInfo((int)id);
            if (file == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var deleteFile = file.ToFilesInfoMapModel();
            return View(deleteFile);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FileService.DeleteFileInfo(id);
            FileService.SaveFileInfo();
            return RedirectToAction("Index");
        }
        public FileResult Download(int id)
        {
            var file = FileService.GetFileInfo(id);
            byte[] fileBytes = file.FileBytes;
            var fileName = String.Format("{0}{1}", file.FileName, file.Extension);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}