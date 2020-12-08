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
    public class ActivityManager : GenericManager<Activity>, IActivityService
    {
        private readonly IGenericDal<Activity> _genericDal;
        public ActivityManager(IGenericDal<Activity> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
        public new async Task<Activity> GetByIdAsync(int id)
        {
            return await _genericDal.GetByFilter(I => I.Id == id && I.IsVisible==true );
        }
        public async Task<List<Activity>> GetActivitiesByAppUserIdAsync(int appuserid)
        {
            return await _genericDal.GetAllByFilter(I => I.AppUserId == appuserid && I.IsVisible==true);
        }
    }
}
