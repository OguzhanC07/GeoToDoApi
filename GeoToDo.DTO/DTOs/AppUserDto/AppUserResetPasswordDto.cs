using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.DTO.DTOs.AppUserDto
{
    public class AppUserResetPasswordDto
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
    }
}
