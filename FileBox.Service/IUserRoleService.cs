using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;

namespace FileBox.Service
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
