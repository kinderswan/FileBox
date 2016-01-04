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
    public interface IUserRoleService
    {
        UserRole GetRole(string role);
    }
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }


        public UserRole GetRole(string role)
        {
            return _userRoleRepository.Get(u => u.Role == role);
        }
    }
}
