using System.Collections.Generic;
using FileBox.Model.Models;

namespace FileBox.Service.Interfaces
{
    public interface IUserRoleService
    {
        UserRole GetRoleInfo(string role);
        UserRole GetRoleInfo(int id);
        IEnumerable<UserRole> GetRoleInfos();
        void CreateRole(UserRole userRole);
        void UpdateRole(UserRole userRole);
        void DeleteUserRole(int id);
        void SaveUserRole();
    }
}
