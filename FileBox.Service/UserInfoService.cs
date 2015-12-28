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
    public interface IUserInfoService
    {
        //get all for admin
        IEnumerable<UserInfo> GetUserInfos();
        UserInfo GetUserInfo(int id);
        void CreateUserInfo(UserInfo userInfo);
        void UpdateUserInfo(int id);
        void DeleteUserInfo(int id);
        void SaveUserInfo();
    }
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserInfoService(IUserInfoRepository userInfoRepository, IUnitOfWork unitOfWork)
        {
            _userInfoRepository = userInfoRepository;
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<UserInfo> GetUserInfos()
        {
            return _userInfoRepository.GetAll();
        }

        public UserInfo GetUserInfo(int id)
        {
            return _userInfoRepository.GetById(id);
        }

        public void CreateUserInfo(UserInfo userInfo)
        {
            _userInfoRepository.Add(userInfo);
        }

        public void UpdateUserInfo(int id)
        {
            _userInfoRepository.Update(_userInfoRepository.GetById(id));
        }

        public void DeleteUserInfo(int id)
        {
            _userInfoRepository.Delete(_userInfoRepository.GetById(id));
        }

        public void SaveUserInfo()
        {
            _unitOfWork.Commit();
        }
    }
}
