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
    public interface IFilesInfoService
    {
        IEnumerable<FilesInfo> GetFilesInfos(); 
        string GetFileShortUrl(int id);
        FilesInfo GetFileInfo(int id);
        void CreateFileInfo(FilesInfo fileInfo);
        void UpdateFileInfo(int id);
        void DeleteFileInfo(int id);
        void SaveFileInfo();
    }
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

        public string GetFileShortUrl(int id)
        {
            return _filesInfoRepository.GetById(id).ShortUrl;
        }

        public FilesInfo GetFileInfo(int id)
        {
            return _filesInfoRepository.GetById(id);
        }

        public void CreateFileInfo(FilesInfo fileInfo)
        {
            _filesInfoRepository.Add(fileInfo);
        }

        public void UpdateFileInfo(int id)
        {
            _filesInfoRepository.Update(_filesInfoRepository.GetById(id));
        }

        public void DeleteFileInfo(int id)
        {
            _filesInfoRepository.Delete(_filesInfoRepository.GetById(id));
        }

        public void SaveFileInfo()
        {
            _unitOfWork.Commit();
        }
    }
}
