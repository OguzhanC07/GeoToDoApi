using GeoToDo.Business.Interfaces;
using GeoToDo.DataAccess.Interfaces;
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
        public AppUserManager(IAppUserDal appUserDal,IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _appUserDal = appUserDal;
            _genericDal = genericDal;
        }

        public async Task<AppUser> FindByEmail(string email)
        {
           return await _genericDal.GetByFilter(I => I.Email == email);
        }

        public async Task<List<AppRole>> GetRolesByEmail(string email)
        {
            return await _appUserDal.GetRolesByEmail(email);
        }
    }
}
