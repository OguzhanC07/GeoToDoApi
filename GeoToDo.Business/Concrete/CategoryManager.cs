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
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        public CategoryManager(IGenericDal<Category> genericDal): base(genericDal)
        {
            _genericDal = genericDal;
        }

        public new async Task<Category> GetByIdAsync(int id)
        {
            return await _genericDal.GetByFilter(I => I.IsVisible == true && I.Id == id);
        }

        public async Task<List<Category>> GetCategoryByAppUserId(int appuserId)
        {
            return await _genericDal.GetAllByFilter(I => I.AppUserId == appuserId && I.IsVisible == true);
        }
    }
}
