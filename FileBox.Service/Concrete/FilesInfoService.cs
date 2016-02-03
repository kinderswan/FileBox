using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FileBox.Data.Infrastructure.Interfaces;
using FileBox.Data.Repository.Interfaces;
using FileBox.Model.Models;
using FileBox.Service.Interfaces;

namespace FileBox.Service.Concrete
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

        public IEnumerable<FilesInfo> GetFilesInfos(Expression<Func<FilesInfo, bool>> where)
        {
            return _filesInfoRepository.GetMany(where);
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
