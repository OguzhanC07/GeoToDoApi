using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Entities.Concrete
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePaths { get; set; }
        public bool IsVisible { get; set; }
        public DateTime SelectedTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ParentActivityId { get; set; }
        public Activity ParentActivity { get; set; }

        public List<Activity> SubActivities { get; set; }


    }
}
