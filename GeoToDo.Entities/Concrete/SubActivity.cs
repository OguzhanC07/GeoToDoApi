using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Entities.Concrete
{
    public class SubActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime SelectedTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsVisible { get; set; }


        public int ActivtyId { get; set; }
        public Activity Activity { get; set; }
    }
}
