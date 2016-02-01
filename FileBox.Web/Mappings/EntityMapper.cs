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
            if (mapModel != null)
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
            return null;
        }

        public static FilesInfoMapModel ToFilesInfoMapModel(this FilesInfo filesInfo)
        {
            if (filesInfo != null)
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
            return null;
        }

        public static FilesInfo ToFilesInfo(this FilesInfoUploadModel upModel)
        {
            if (upModel != null)
                return new FilesInfo
                {
                    Extension = Path.GetExtension(upModel.File.FileName),
                    FileAccess = upModel.FileAccess,
                    FileName = Path.GetFileNameWithoutExtension(upModel.File.FileName),
                    ShortUrl = String.Format("{0:X}", upModel.File.FileName.GetHashCode() + DateTime.Now.GetHashCode()),
                    UserInfoID = upModel.UserID
                };
            return null;
        }

        public static UserInfo ToUserInfo(this UserInfoMapModel mapModel)
        {
            if (mapModel != null)
                return new UserInfo
                {
                    Email = mapModel.Email,
                    FirstName = mapModel.FirstName,
                    LastName = mapModel.LastName,
                    Login = mapModel.Login,
                    Password = Crypto.SHA1(mapModel.Password),
                    UserInfoID = mapModel.UserInfoID,
                    UserRoleID = mapModel.UserRoleID
                };
            return null;
        }

        public static UserInfoMapModel ToUserInfoMapModel(this UserInfo userInfo)
        {
            if (userInfo != null)
                return new UserInfoMapModel
                {
                    Email = userInfo.Email,
                    Files = userInfo.Files.Select(f => f.ToFilesInfoMapModel()).ToList(),
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Login = userInfo.Login,
                    Password = userInfo.Password,
                    UserInfoID = userInfo.UserInfoID,
                    UserRole = userInfo.UserRole.ToUserRoleMapModel(),
                    UserRoleID = userInfo.UserRoleID,
                    WasCreated = userInfo.WasCreated
                };
            return null;
        }

        public static UserInfo ToUserInfo(this UserInfoRegisterModel regModel)
        {
            if (regModel != null)
                return new UserInfo
                {
                    Email = regModel.Email,
                    Login = regModel.Login,
                    Password = Crypto.SHA1(regModel.Password)
                };
            return null;
        }
        public static UserRole ToUserRole(this UserRoleMapModel mapModel)
        {
            if (mapModel != null)
                return new UserRole
                {

                    Role = mapModel.Role,
                    RoleDescription = mapModel.RoleDescription,
                    UserRoleID = mapModel.UserRoleID
                };
            return null;
        }

        public static UserRoleMapModel ToUserRoleMapModel(this UserRole userRole)
        {
            if (userRole != null)
                return new UserRoleMapModel
                {
                    Role = userRole.Role,
                    RoleDescription = userRole.RoleDescription,
                    UserRoleID = userRole.UserRoleID
                };
            return null;
        }
    }
}