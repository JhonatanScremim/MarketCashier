using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCashier.App.Settings
{
    public static class ApiSettings
    {
        public static string Url { get; set; } = "http://localhost:5247/";
        public static string Username { get; set; } = "admin";
        public static string Password { get; set; } = "admin";
        public static string? Token { get; set; }

    }
}
