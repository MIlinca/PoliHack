using AlzBuddy2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzBuddy2.CriticalStates
{
    internal class CheckForErrors
    {
        public AlzBuddyDB db = new AlzBuddyDB();

        public void Check(double temperature, double co, int water, int door)
        {
            ErrorMessages errorMessages = new ErrorMessages();
            ReturnError error;
            CriticLevel criticLevel = new CriticLevel();

            DateTime now = DateTime.Now;

            DateTime currentDateAndTime = DateTime.Now;

            // Extract the current hour as a string
            string currentHour = currentDateAndTime.ToString("HH:mm");

            // Extract the current date as a string
            string currentDate = currentDateAndTime.ToString("yyyy-MM-dd");

            error = null;
            error = errorMessages.CheckTemperatureLevel(temperature);
            if (error != null)
            {
                criticLevel.State = error.state;
                criticLevel.Message = error.message;
                criticLevel.Value = temperature;
                criticLevel.Hour = currentHour;
                criticLevel.Date = currentDate;

                db.CriticLevels.Add(criticLevel);
                db.SaveChanges();
            }

            error = null;
            error = errorMessages.CheckCarbonMonoxideLevel(co);
            if (error != null)
            {
                criticLevel.State = error.state;
                criticLevel.Message = error.message;
                criticLevel.Value = co;
                criticLevel.Hour = currentHour;
                criticLevel.Date = currentDate;

                db.CriticLevels.Add(criticLevel);
                db.SaveChanges();               
            }

            error = null;
            error = errorMessages.CheckWaterLevel(water);
            if (error != null)
            {
                criticLevel.State = error.state;
                criticLevel.Message = error.message;
                criticLevel.Value = water;
                criticLevel.Hour = currentHour;
                criticLevel.Date = currentDate;

                db.CriticLevels.Add(criticLevel);
                db.SaveChanges();
            }

            error = null;
            error = errorMessages.CheckFridgeDoor(door);
            if (error != null)
            {
                criticLevel.State = error.state;
                criticLevel.Message = error.message;
                criticLevel.Value = door/60;
                criticLevel.Hour = currentHour;
                criticLevel.Date = currentDate;

                db.CriticLevels.Add(criticLevel);
                db.SaveChanges();
            }
        }
    }
}
