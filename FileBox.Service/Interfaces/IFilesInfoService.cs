using System.Collections.Generic;
using FileBox.Model.Models;

namespace FileBox.Service.Interfaces
{
    public interface IFilesInfoService
    {
        IEnumerable<FilesInfo> GetFilesInfos();
        FilesInfo GetFileInfo(int id);
        FilesInfo GetFileInfo(string shortUrl);
        void CreateFileInfo(FilesInfo fileInfo);
        void UpdateFileInfo(FilesInfo fileInfo);
        void DeleteFileInfo(int id);
        void SaveFileInfo();
    }
}
