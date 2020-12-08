using GeoToDo.DataAccess.Concrete.EntityFrameworkCore.Context;
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
    public class EfActivityRepository : EfGenericRepository<Activity>, IActivityDal
    {
        
    }
}
