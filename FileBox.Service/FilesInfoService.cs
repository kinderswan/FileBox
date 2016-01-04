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
        IEnumerable<FilesInfo> GetUserFiles(int userID);
            FilesInfo GetFileInfo(int id);
        UserInfo GetUserInfoFromFile(int id);
        void CreateFileInfo(FilesInfo fileInfo);
        void UpdateFileInfo(int id);
        void DeleteFileInfo(int id);
        void SaveFileInfo();
    }
    public class FilesInfoService : IFilesInfoService
    {
        private readonly IFilesInfoRepository _filesInfoRepository;
        private readonly IUserInfoRepository _userInfoRepository;

        private readonly IUnitOfWork _unitOfWork;

        public FilesInfoService(IFilesInfoRepository filesInfoRepository, IUserInfoRepository userInfoRepository, IUnitOfWork unitOfWork)
        {
            _filesInfoRepository = filesInfoRepository;
            _userInfoRepository = userInfoRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<FilesInfo> GetFilesInfos()
        {
            return _filesInfoRepository.GetAll();
        }

        public IEnumerable<FilesInfo> GetUserFiles(int userID)
        {
            return _filesInfoRepository.GetMany(f => f.UserInfoID == userID);
        }

        public FilesInfo GetFileInfo(int id)
        {
            return _filesInfoRepository.GetById(id);
        }

        public UserInfo GetUserInfoFromFile(int id)
        {
            return _filesInfoRepository.GetById(id).UserInfo;
        }

        public void CreateFileInfo(FilesInfo fileInfo)//change that
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
