using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.DataAccess.Interfaces
{
    public interface IGenericDal<T> where T: class,new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        
        Task<T> GetByFilter(Expression<Func<T,bool>> expression);
        Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);


    }
}
