using GeoToDo.DTO.DTOs.AppUserDto;
using GeoToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto);
        Task<AppUser> FindUserAsync(string value);
        Task<List<AppRole>> GetRolesByEmailOrUserNameAsync(string value);
    }
}
