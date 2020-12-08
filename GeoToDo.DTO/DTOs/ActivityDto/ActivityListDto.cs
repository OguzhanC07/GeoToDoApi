using System;
using System.Collections.Generic;
using System.Text;

namespace GeoToDo.DTO.DTOs.ActivityDto
{
    public class ActivityListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime SelectedTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
