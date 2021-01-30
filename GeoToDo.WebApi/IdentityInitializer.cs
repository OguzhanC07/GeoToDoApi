using GeoToDo.Business.Interfaces;
using GeoToDo.Business.StringInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoToDo.WebApi
{
    public static class IdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByNameAsync(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.AddAsync(new Entities.Concrete.AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await appRoleService.FindByNameAsync(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.AddAsync(new Entities.Concrete.AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByEmail("test@test.com");
            if (adminUser == null)
            {
                string password = BCrypt.Net.BCrypt.HashPassword("1");

                await appUserService.AddAsync(new Entities.Concrete.AppUser
                {
                    Name = "Admin Test",
                    Password = password,
                    Email = "test@test.com",
                    ImagePath="default.jpg",
                    UserName="Admin Username",
                    Surname="Admin Surname",
                });


                var role = await appRoleService.FindByNameAsync(RoleInfo.Admin);
                var admin = await appUserService.FindByEmail("test@test.com");

                await appUserRoleService.AddAsync(new Entities.Concrete.AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}
