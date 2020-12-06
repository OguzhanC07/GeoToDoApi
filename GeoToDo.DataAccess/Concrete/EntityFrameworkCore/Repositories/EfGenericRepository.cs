using GeoToDo.DataAccess.Concrete.EntityFrameworkCore.Context;
using GeoToDo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        
        public async Task AddAsync(T entity)
        {
            using var context = new GeoToDoDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new GeoToDoDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> expression)
        {
            using var context = new GeoToDoDbContext();
            return await context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> expression)
        {
            using var context = new GeoToDoDbContext();
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using var context = new GeoToDoDbContext();
            return await context.FindAsync<T>(id);
        }

        public async Task RemoveAsync(T entity)
        {
            using var context = new GeoToDoDbContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new GeoToDoDbContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
