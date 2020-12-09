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
    public class TargetManager : GenericManager<Target>, ITargetService
    {
        private readonly IGenericDal<Target> _genericDal;
        public TargetManager(IGenericDal<Target> genericDal): base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<Target>> GetTargetsByAppUserId(int id)
        {
            return await _genericDal.GetAllByFilter(I => I.AppUserId == id);
        }
    }
}
