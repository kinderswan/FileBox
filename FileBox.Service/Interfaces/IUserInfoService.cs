using System.Collections.Generic;
using FileBox.Model.Models;

namespace FileBox.Service.Interfaces
{
    public interface IUserInfoService
    {
        IEnumerable<UserInfo> GetUserInfos();
        UserInfo GetUserInfo(string email);
        UserInfo GetUserInfo(int id);
        UserInfo GetUserInfo(string email, string password);
        void CreateUserInfo(UserInfo userInfo);
        void UpdateUserInfo(UserInfo userInfo);
        void DeleteUserInfo(int id);
        void SaveUserInfo();
    }
}
