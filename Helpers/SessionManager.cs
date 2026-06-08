using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_Travel_Planner_Frontend.Helpers
{
    public static class SessionManager
    {
        public static string Token { get; set; } = string.Empty;

        public static int UserId { get; set; }

        public static string Role { get; set; } = string.Empty;

        public static string Username { get; set;} = string.Empty;
    }
}
