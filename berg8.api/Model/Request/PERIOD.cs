using System;
namespace berg8.api.Model
{
    public class PERIOD
    {
        public string BEGIN { get; set; }
        public string END { get; set; }
        public PERIOD()
        {
            BEGIN = $"{DateTime.Today:yyyy-MM-dd}";
            END = $"{new DateTime(9999, 12, 31):yyyy-MM-dd}";
        }
    }
}
