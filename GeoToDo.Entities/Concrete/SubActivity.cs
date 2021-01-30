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
        public bool IsVisible { get; set; } = true;


        public int ActivtyId { get; set; }
        public Activity Activity { get; set; }
    }
}
