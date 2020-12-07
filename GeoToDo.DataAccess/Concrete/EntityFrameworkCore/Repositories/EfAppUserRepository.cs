﻿using GeoToDo.DataAccess.Concrete.EntityFrameworkCore.Context;
using GeoToDo.DataAccess.Interfaces;
using GeoToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public async Task<List<AppRole>> GetRolesByEmailOrUserNameAsync(string value)
        {
            using var context = new GeoToDoDbContext();

            return await context.AppUsers.Join(context.AppUserRoles, u => u.Id, ur => ur.AppUserId, (user, userRole) => new
            {
                user,
                userRole
            }).Join(context.AppRoles, two => two.userRole.AppRoleId, r => r.Id, (twoTable, role) => new
            {
                twoTable.user,
                twoTable.userRole,
                role
            }).Where(I => I.user.Email == value || I.user.UserName == value).Select(I => new AppRole
            {
                Id = I.role.Id,
                Name = I.role.Name
            }).ToListAsync();
        }
    }
}
