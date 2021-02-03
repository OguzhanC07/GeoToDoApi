using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Entities.Concrete
{
    public class Target
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SavedTime { get; set; } = DateTime.Now;
        public DateTime AchievedTime { get; set; }
        public bool isAchieved { get; set; } = false;

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
