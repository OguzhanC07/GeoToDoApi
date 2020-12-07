using GeoToDo.DataAccess.Concrete.EntityFrameworkCore.Context;
using GeoToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.DataAccess.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
       Task<List<AppRole>> GetRolesByEmailOrUserNameAsync(string value);
    }
}
