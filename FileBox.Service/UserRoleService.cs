﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Data.Infrastructure;
using FileBox.Data.Repository;
using FileBox.Model.Models;

namespace FileBox.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }
        public UserRole GetRoleInfo(string role)
        {
            return _userRoleRepository.Get(u => u.Role == role);
        }

        public UserRole GetRoleInfo(int id)
        {
            return _userRoleRepository.GetById(id);
        }

        public IEnumerable<UserRole> GetRoleInfos()
        {
            return _userRoleRepository.GetAll();
        }

        public void CreateRole(UserRole userRole)
        {
            _userRoleRepository.Add(userRole);
        }

        public void UpdateRole(UserRole userRole)
        {
            _userRoleRepository.Update(userRole);
        }

        public void DeleteUserRole(int id)
        {
            _userRoleRepository.Delete(r => r.UserRoleID == id);
        }

        public void SaveUserRole()
        {
            _unitOfWork.Commit();
        }
    }
}
