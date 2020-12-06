using GeoToDo.Business.Settings;
using GeoToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Interfaces
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser, List<AppRole> roles);
    }
}
