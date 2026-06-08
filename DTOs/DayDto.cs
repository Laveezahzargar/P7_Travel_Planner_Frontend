using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_Travel_Planner_Frontend.DTOs
{
    public class DayDto
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public DateTime Date { get; set; }
        public int DayNumber { get; set; }
        public string Destination { get; set; }
        public string Notes { get; set; }
    }
}
