using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;

namespace FileBox.Service
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
