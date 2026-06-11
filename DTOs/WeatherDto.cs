using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_Travel_Planner_Frontend.DTOs
{
    public class WeatherDto
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public string Condition { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
    }
}
