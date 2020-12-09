using GeoToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        new Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetCategoryByAppUserId(int appuserId);
    }
}
