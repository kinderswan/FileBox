using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FileBox.Model.Models;

namespace FileBox.Service.Interfaces
{
    public interface IUserInfoService
    {
        IEnumerable<UserInfo> GetUserInfos();
        IEnumerable<UserInfo> GetUserInfos(Expression<Func<UserInfo, bool>> where);
        UserInfo GetUserInfo(string email);
        UserInfo GetUserInfo(int id);
        UserInfo GetUserInfo(string email, string password);
        void CreateUserInfo(UserInfo userInfo);
        void UpdateUserInfo(UserInfo userInfo);
        void DeleteUserInfo(int id);
        void SaveUserInfo();
    }
}
