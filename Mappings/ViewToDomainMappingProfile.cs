using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AutoMapper;
using FileBox.Model.Models;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Mappings
{
    public class ViewToDomainMappingProfile : Profile
    {
        public new string ProfileName
        {
            get { return "DomainToViewMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<FilesInfoFormModel, FilesInfo>()
                .ForMember(f => f.FileName, map => map.MapFrom(vm => Path.GetFileNameWithoutExtension(vm.File.FileName)))
                .ForMember(f => f.Extension, map => map.MapFrom(vm => Path.GetExtension(vm.File.FileName)))
                .ForMember(f => f.FileAccess, map => map.MapFrom(vm => vm.FileAccess))
                .ForMember(f => f.ShortUrl,
                    map =>
                        map.MapFrom(
                            vm => String.Format("{0:X}", vm.File.FileName.GetHashCode() + DateTime.Now.GetHashCode())))
                .ForMember(f => f.UserInfoID, map => map.MapFrom(vm => vm.UserID));
            
            Mapper.CreateMap<UserInfoFormModel, UserInfo>()
                .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.UserName))
                .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.UserSurname))
                .ForMember(u => u.Login, map => map.MapFrom(vm => vm.Login))
                .ForMember(u => u.Password, map => map.MapFrom(vm => vm.Password))
                .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email));

            Mapper.CreateMap<UserRoleFormModel, UserRole>();
            Mapper.CreateMap<UserInfoAdminModel, UserInfo>();
            Mapper.CreateMap<FilesInfoAdminModel, FilesInfo>();


        }
    }
}