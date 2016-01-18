﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FileBox.Model.Models;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public new string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<FilesInfo, FilesInfoViewModel>();
            Mapper.CreateMap<UserInfo, UserInfoViewModel>();
            Mapper.CreateMap<UserRole, UserRoleViewModel>();
            Mapper.CreateMap<UserInfo, UserInfoAdminModel>();
            Mapper.CreateMap<FilesInfo, FilesInfoAdminModel>();
            Mapper.CreateMap<UserRole, UserRoleFormModel>();
            Mapper.CreateMap<UserInfoAdminModel, UserInfoViewModel>();
            Mapper.CreateMap<FilesInfoAdminModel, FilesInfoViewModel>();
        }
    }
}