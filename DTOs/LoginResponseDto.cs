using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_Travel_Planner_Frontend.DTOs
{
    public class LoginResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Role { get; set; } 
        public string Token { get; set; } = string.Empty;
    }
}
