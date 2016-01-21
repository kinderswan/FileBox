using System;
using System.Collections.Generic;
using FileBox.Data.Infrastructure.Interfaces;
using FileBox.Data.Repository.Interfaces;
using FileBox.Model.Models;
using FileBox.Service.Interfaces;

namespace FileBox.Service.Concrete
{
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

        public UserInfo GetUserInfo(string email)
        {
            return _userInfoRepository.Get(u => string.Compare(u.Email, email, true) == 0);
        }

        public UserInfo GetUserInfo(int id)
        {
            return _userInfoRepository.GetById(id);
        }

        public UserInfo GetUserInfo(string email, string password)
        {
            return
                _userInfoRepository.Get(u => String.Compare(u.Email, email, true) == 0 && u.Password == password);
        }

        public void CreateUserInfo(UserInfo userInfo)
        {
            _userInfoRepository.Add(userInfo);
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            _userInfoRepository.Update(userInfo);
        }

        public void DeleteUserInfo(int id)
        {
            _userInfoRepository.Delete(u => u.UserInfoID == id);
        }

        public void SaveUserInfo()
        {
            _unitOfWork.Commit();
        }
    }
}
