using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_Travel_Planner_Frontend.DTOs
{
        public class TripDto
        {
            public int Id { get; set; }

            public string Title { get; set; } = string.Empty;

            public int DestinationId { get; set; }

            public string Destination { get; set; } = string.Empty;

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public int Status { get; set; } 
        }
    
}
