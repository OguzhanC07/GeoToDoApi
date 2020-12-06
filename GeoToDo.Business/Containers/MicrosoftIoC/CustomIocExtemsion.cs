using GeoToDo.Business.Concrete;
using GeoToDo.Business.Interfaces;
using GeoToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using GeoToDo.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Containers.MicrosoftIoC
{
    public static class CustomIocExtemsion
    {
        public static void AddDependicies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IActivityDal, EfActivityRepository>();
            services.AddScoped<IActivityService, ActivityManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ITargetDal, EfTargetRepository>();
            services.AddScoped<ITargetService, TargetManager>();
        }
    }
}
