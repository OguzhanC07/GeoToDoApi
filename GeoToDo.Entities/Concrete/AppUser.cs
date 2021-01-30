using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Entities.Concrete
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
        public bool IsVisible { get; set; } = true;
        
        public List<AppUserRole> AppUserRoles { get; set; }
        public List<Target> Targets { get; set; }
        public List<Category> Categories { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
