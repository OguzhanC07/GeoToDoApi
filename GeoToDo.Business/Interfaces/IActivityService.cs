using GeoToDo.DTO.DTOs.CategoryDto;
using GeoToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Interfaces
{
    public interface IActivityService : IGenericService<Activity>
    {
        new Task<Activity> GetByIdAsync(int id);
        Task<List<Activity>> GetActivitiesByAppUserIdAsync(int appuserid);

        Task AddToCategory(CategoryActivityDto categoryActivityDto);
        Task RemoveFromCategory(CategoryActivityDto categoryActivityDto);
    }
}
