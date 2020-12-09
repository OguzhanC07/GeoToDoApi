using GeoToDo.Business.Interfaces;
using GeoToDo.DataAccess.Interfaces;
using GeoToDo.DTO.DTOs.CategoryDto;
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
        private readonly IGenericDal<CategoryActivity> _categoryActivityDal;
        public ActivityManager(IGenericDal<CategoryActivity> categoryActivityDal, IGenericDal<Activity> genericDal) : base(genericDal)
        {
            _categoryActivityDal = categoryActivityDal;
            _genericDal = genericDal;
        }
        public new async Task<Activity> GetByIdAsync(int id)
        {
            return await _genericDal.GetByFilter(I => I.Id == id && I.IsVisible == true);
        }
        public async Task<List<Activity>> GetActivitiesByAppUserIdAsync(int appuserid)
        {
            return await _genericDal.GetAllByFilter(I => I.AppUserId == appuserid && I.IsVisible == true);
        }

        public async Task AddToCategory(CategoryActivityDto categoryActivityDto)
        {
            var check = await _categoryActivityDal.GetByFilter(I => I.CategoryId
            == categoryActivityDto.CategoryId && I.ActivityId
            == categoryActivityDto.ActivityId);

            if (check == null)
            {
                await _categoryActivityDal.AddAsync(new CategoryActivity
                {
                    ActivityId = categoryActivityDto.ActivityId,
                    CategoryId = categoryActivityDto.CategoryId
                });
            }
        }

        public async Task RemoveFromCategory(CategoryActivityDto categoryActivityDto)
        {
            var check = await _categoryActivityDal.GetByFilter(I => I.CategoryId
           == categoryActivityDto.CategoryId && I.ActivityId
           == categoryActivityDto.ActivityId);

            if (check!=null)
            {
                await _categoryActivityDal.RemoveAsync(check);
            }
        }
    }
}
