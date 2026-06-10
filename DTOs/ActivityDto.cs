using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_Travel_Planner_Frontend.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }

        public int ItineraryDayId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public decimal Cost { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
