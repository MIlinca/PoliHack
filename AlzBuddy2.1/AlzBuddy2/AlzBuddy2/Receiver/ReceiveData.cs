using AlzBuddy2.CriticalStates;
using AlzBuddy2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlzBuddy2.Receiver
{
    internal class ReceiveData
    {
        public AlzBuddyDB db = new AlzBuddyDB();

        public void AddReceivedData(string message)
        {

            //{"Temperature(C)": "23.00", "CO PPM": "266.85", "Door_open_seconds": "4", "Water Level": "0", "Distance": "129.40"}
            StateValue values = new StateValue();

            string pattern = "\"([0-9]+(\\.[0-9]+)?)\"";

            // Use Regex to match the pattern and extract numbers
            MatchCollection matches = Regex.Matches(message, pattern);

            // Declare variables to store the extracted numbers
            double temperature = 0;
            double coPpm = 0;
            int doorOpenSeconds = 0;
            int waterLevel = 0;

            // Extract and assign the matched numbers to variables
            if (matches.Count >= 1) double.TryParse(matches[0].Groups[1].Value, out temperature);
            if (matches.Count >= 2) double.TryParse(matches[1].Groups[1].Value, out coPpm);
            if (matches.Count >= 3) int.TryParse(matches[2].Groups[1].Value, out doorOpenSeconds);
            if (matches.Count >= 4) int.TryParse(matches[3].Groups[1].Value, out waterLevel);

            DateTime now = DateTime.Now;
            DateTime currentDateAndTime = DateTime.Now;

            // Extract the current hour as a string
            string currentHour = currentDateAndTime.ToString("HH");
            // Extract the current date as a string
            string currentDate = currentDateAndTime.ToString("yyyy-MM-dd");


            values.TemperatureValue = temperature;
            values.WaterLevelValue = waterLevel;
            values.CarbonMonoxideValue = coPpm;
            values.FridgeDoorOpenMinutes = doorOpenSeconds;
            values.Hour = currentHour;
            values.Date = currentDate;

            db.StateValues.Add(values);
            db.SaveChanges();

            CheckForErrors checkForErrors = new CheckForErrors();
            checkForErrors.Check(temperature, coPpm, waterLevel, doorOpenSeconds);
        }
    }
}
