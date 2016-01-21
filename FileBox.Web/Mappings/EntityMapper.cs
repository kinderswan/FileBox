using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FileBox.Model.Models;
using FileBox.Web.Global.Auth;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Mappings
{
    public static class EntityMapper
    {
        public static FilesInfo ToFilesInfo(this FilesInfoMapModel mapModel)
        {
            return new FilesInfo()
            {
                FilesInfoID = mapModel.FilesInfoID,
                Extension = mapModel.Extension,
                FileAccess = mapModel.FileAccess,
                FileName = mapModel.FileName,
                ShortUrl = mapModel.ShortUrl,
                UserInfoID = mapModel.UserInfoID,
                WasCreated = mapModel.WasCreated
            };
        }

        public static FilesInfoMapModel ToFilesInfoMapModel(this FilesInfo filesInfo)
        {
            return new FilesInfoMapModel
            {
                Extension = filesInfo.Extension,
                FileAccess = filesInfo.FileAccess,
                FileName = filesInfo.FileName,
                FilesInfoID = filesInfo.FilesInfoID,
                ShortUrl = filesInfo.ShortUrl,
                UserInfoID = filesInfo.UserInfoID,
                WasCreated = filesInfo.WasCreated
            };
        }

        public static FilesInfo ToFilesInfo(this FilesInfoUploadModel upModel)
        {
            return new FilesInfo
            {
                Extension = Path.GetExtension(upModel.File.FileName),
                FileAccess = upModel.FileAccess,
                FileName = Path.GetFileNameWithoutExtension(upModel.File.FileName),
                ShortUrl = String.Format("{0:X}", upModel.File.FileName.GetHashCode() + DateTime.Now.GetHashCode()),
                UserInfoID = upModel.UserID
            };
        }

        public static UserInfo ToUserInfo(this UserInfoMapModel mapModel)
        {
            return new UserInfo
            {
                Email = mapModel.Email,
                FirstName = mapModel.FirstName,
                LastName = mapModel.LastName,
                Login = mapModel.Login,
                Password = mapModel.Password,
                UserInfoID = mapModel.UserInfoID,
                UserRoleID = mapModel.UserRoleID
            };
        }

        public static UserInfoMapModel ToUserInfoMapModel(this UserInfo userInfo)
        {
            return new UserInfoMapModel
            {
                Email = userInfo.Email,
                Files = userInfo.Files.Select(f=>f.ToFilesInfoMapModel()).ToList(),
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Login = userInfo.Login,
                Password = userInfo.Password,
                UserInfoID = userInfo.UserInfoID,
                UserRole = userInfo.UserRole.ToUserRoleMapModel(),
                UserRoleID = userInfo.UserRoleID,
                WasCreated = userInfo.WasCreated
            };
        }

        public static UserInfo ToUserInfo(this UserInfoRegisterModel regModel)
        {
            return new UserInfo
            {
                Email = regModel.Email,
                Login = regModel.Login,
                Password = Crypto.SHA1(regModel.Password)
            };
        }
        public static UserRole ToUserRole(this UserRoleMapModel mapModel)
        {
            return new UserRole
            {

                Role = mapModel.Role,
                RoleDescription = mapModel.RoleDescription,
                UserRoleID = mapModel.UserRoleID
            };
        }

        public static UserRoleMapModel ToUserRoleMapModel(this UserRole userRole)
        {
            return new UserRoleMapModel
            {
                Role = userRole.Role,
                RoleDescription = userRole.RoleDescription,
                UserRoleID = userRole.UserRoleID
            };
        }
    }
}