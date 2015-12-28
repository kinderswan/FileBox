using System;
using System.Collections.Generic;
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
            Mapper.CreateMap<FilesFormModel, FilesInfo>()
                .ForMember(f => f.FileName, map => map.MapFrom(vm => vm.FileName))
                .ForMember(f => f.FileAccess, map => map.MapFrom(vm => vm.FileAccess));
        }
    }
}