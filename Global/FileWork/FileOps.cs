using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FileBox.Data.Infrastructure;
using FileBox.Service;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Global.FileWork
{
    public interface IFileOps
    {
        Task ChangeFileNameAsync(FilesInfoAdminModel oldModel, FilesInfoAdminModel newModel);
        Task DeleteFileAsync(FilesInfoAdminModel deleteModel);
    }
    public class FileOps : IFileOps
    {
        private readonly IUserInfoService _uService;
        public FileOps() { }

        public FileOps(IUserInfoService uService)
        {
            _uService = uService;
        }
        public async Task ChangeFileNameAsync(FilesInfoAdminModel oldModel, FilesInfoAdminModel newModel)
        {
            var userDir = _uService.GetUserInfo(newModel.UserInfoID).DirectoryPath;
            var oldPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", userDir, oldModel.FileName + oldModel.Extension);
            var newPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", userDir, newModel.FileName + newModel.Extension);
            await Task.Factory.StartNew(() => System.IO.File.Move(oldPath, newPath));
        }

        public async Task DeleteFileAsync(FilesInfoAdminModel deleteModel)
        {
            var userDirectoryPath = _uService.GetUserInfo(deleteModel.UserInfoID).DirectoryPath;
            var deletePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files",
                userDirectoryPath, deleteModel.FileName + deleteModel.Extension);
            await Task.Factory.StartNew(() => System.IO.File.Delete(deletePath));
        }
    }
}