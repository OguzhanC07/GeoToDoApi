using AutoMapper;
using GeoToDo.DTO.DTOs.AppUserDto;
using GeoToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoToDo.WebApi.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region AppUser
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserAddDto, AppUser>();

            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();
            #endregion
        }
    }
}
