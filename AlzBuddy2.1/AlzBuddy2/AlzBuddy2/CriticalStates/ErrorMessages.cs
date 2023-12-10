using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzBuddy2.CriticalStates
{
    public class ErrorMessages
    {
        public ReturnError CheckTemperatureLevel(double value)
        {
            string state = "", message = "";
            ReturnError error = null;

            if (value >= 0 && value <= 16)
            {
                message = "Temperature value is below 16°C.";
                state = "ERROR";

                error = new ReturnError(state, message);
            }
            else if (value >= 35 && value <= 50)
            {
                message = "Temperature value is above 35°C.";
                state = "ERROR";
                error = new ReturnError(state, message);
            }
            else if (value > 16 && value <= 20)
            {
                message = "Temperature value is below 20°C.";
                state = "WARNING";
                error = new ReturnError(state, message);
            }
            else if (value >= 28 && value < 35)
            {
                message = "Temperature value is above 28°C.";
                state = "WARNING";
                error = new ReturnError(state, message);
            }

            return error;
        }

        public ReturnError CheckWaterLevel(int value)
        {
            string state = "", message = "";
            ReturnError error = null;

            if (value == 3)
            {
                message = "The sink overflows.";
                state = "ERROR";
                error = new ReturnError(state, message);
            }
            else if (value == 2)
            {
                message = "The sink is almost full.";
                state = "WARNING";
                error = new ReturnError(state, message);
            }                     

            return error;
        }

        public ReturnError CheckCarbonMonoxideLevel(double value)
        {
            string state = "", message = "";
            ReturnError error = null;

            if (value >= 130 && value <= 170)
            {
                message = "The percentage of carbon monoxide is not in normal parameters.";
                state = "WARNING";
                error = new ReturnError(state, message);
            }
            else if (value > 170)
            {
                message = "The percentage of carbon monoxide is in critical state.";
                state = "ERROR";
                error = new ReturnError(state, message);
            }

            return error;
        }

        public ReturnError CheckFridgeDoor(int value)
        {
            string state = "", message = "";
            ReturnError error = null;

            if (value >= 60 && value <= 5*60)
            {
                message = "The fridge door has been open for more than 1 minute.";
                state = "WARNING";
                error = new ReturnError(state, message);
            }
            else if (value > 5*60)
            {
                message = "The fridge door has been open for more than 5 minute.";
                state = "ERROR";
                error = new ReturnError(state, message);
            }

            return error;
        }
    }
}