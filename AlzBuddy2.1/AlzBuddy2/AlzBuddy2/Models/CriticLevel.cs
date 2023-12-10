using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlzBuddy2.Models
{
    public class CriticLevel
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Hour { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string State { get; set; }
    }
}