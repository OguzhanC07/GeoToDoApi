using GeoToDo.Business.Interfaces;
using GeoToDo.DataAccess.Interfaces;
using GeoToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Concrete
{
    public class TargetManager : GenericManager<Target>, ITargetService
    {
        public TargetManager(IGenericDal<Target> genericDal): base(genericDal)
        {

        }
    }
}
