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
    public class AppRoleManager : GenericManager<AppRole>, IAppRoleService
    {
        private readonly IGenericDal<AppRole> _genericDal;
        public AppRoleManager(IGenericDal<AppRole> genericDal): base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppRole> FindByNameAsync(string role)
        {
            return await _genericDal.GetByFilter(I => I.Name == role);
        }
    }
}
