using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.StringInfos
{
    public class JwtInfo
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string SecurityKey = "oguzhanoguzhan11";
        public const int TokenExpiration = 30;
    }
}
