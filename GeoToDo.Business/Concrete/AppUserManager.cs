using GeoToDo.Business.Interfaces;
using GeoToDo.DataAccess.Interfaces;
using GeoToDo.DTO.DTOs.AppUserDto;
using GeoToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal, IGenericDal<AppUser> genericDal): base(genericDal)
        {
            _appUserDal = appUserDal;
            _genericDal = genericDal;
        }

        public async Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            return await _genericDal.GetByFilter(I => I.UserName == appUserLoginDto.EmailOrUserName 
            || I.Email == appUserLoginDto.EmailOrUserName
            && I.Password == appUserLoginDto.Password);
        }

        public async Task<AppUser> FindUserAsync(string value)
        {
            return await _genericDal.GetByFilter(I => I.UserName == value || I.Email == value);
        }

        public async Task<List<AppRole>> GetRolesByEmailOrUserNameAsync(string value)
        {
            return await _appUserDal.GetRolesByEmailOrUserNameAsync(value);
        }
    }
}
