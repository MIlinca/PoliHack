using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzBuddy2.CriticalStates
{
    public class ReturnError
    {
       public string state;
       public string message;

        public ReturnError(string state, string message)
        {
            this.state = state;
            this.message = message;
        }
    }
}
