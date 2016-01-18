using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Data.Infrastructure;
using FileBox.Data.Repository;
using FileBox.Model.Models;

namespace FileBox.Service
{
    public class FilesInfoService : IFilesInfoService
    {
        private readonly IFilesInfoRepository _filesInfoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FilesInfoService(IFilesInfoRepository filesInfoRepository, IUnitOfWork unitOfWork)
        {
            _filesInfoRepository = filesInfoRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<FilesInfo> GetFilesInfos()
        {
            return _filesInfoRepository.GetAll();
        }

        public FilesInfo GetFileInfo(int id)
        {
            return _filesInfoRepository.GetById(id);
        }

        public FilesInfo GetFileInfo(string shortUrl)
        {
            return _filesInfoRepository.Get(t => t.ShortUrl == shortUrl);
        }

        public void CreateFileInfo(FilesInfo fileInfo)
        {
            _filesInfoRepository.Add(fileInfo);
        }

        public void UpdateFileInfo(FilesInfo fileInfo)
        {
            _filesInfoRepository.Update(fileInfo);
        }

        public void DeleteFileInfo(int id)
        {
            _filesInfoRepository.Delete(f => f.FilesInfoID == id);
        }

        public void SaveFileInfo()
        {
            _unitOfWork.Commit();
        }



    }
}
