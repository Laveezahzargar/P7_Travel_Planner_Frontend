using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_Travel_Planner_Frontend.DTOs
{
    public class SelectedPlaceContext
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }

        public int PlaceId { get; set; }
        public string PlaceName { get; set; }

        public string? DestinationDescription { get; set; }

        // ⭐ VERY IMPORTANT (for weather APIs)
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
