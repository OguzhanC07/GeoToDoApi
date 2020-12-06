using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Entities.Concrete
{
    public class ActivityImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public bool IsVisible { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
