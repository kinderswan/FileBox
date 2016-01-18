using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;

namespace FileBox.Service
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
