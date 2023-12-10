using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlzBuddy2.Models
{
    public class StateValue
    {
        public int Id { get; set; }
        public double TemperatureValue { get; set; }
        public int FridgeDoorOpenMinutes { get; set; }
        public int WaterLevelValue { get; set; }
        public double CarbonMonoxideValue { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
    }
}