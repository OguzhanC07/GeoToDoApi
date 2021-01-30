using System;
using System.Collections.Generic;
using System.Text;

namespace GeoToDo.DTO.DTOs.ActivityDto
{
    public class AddActivityDto 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime SelectedTime { get; set; } = DateTime.Today;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public int AppUserId { get; set; }
    }
}
