﻿using GeoToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Interfaces
{
    public interface ITargetService : IGenericService<Target>
    {
        Task<List<Target>> GetTargetsByAppUserId(int id);
    }
}
