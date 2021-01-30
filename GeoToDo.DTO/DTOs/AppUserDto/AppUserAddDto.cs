using System;
using System.Collections.Generic;
using System.Text;

namespace GeoToDo.DTO.DTOs.AppUserDto
{
    public class AppUserAddDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
    }
}
