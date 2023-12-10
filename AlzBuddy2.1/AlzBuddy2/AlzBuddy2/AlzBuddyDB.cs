using AlzBuddy2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AlzBuddy2
{
    public class AlzBuddyDB : DbContext
    {
        public DbSet<CriticLevel> CriticLevels { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<StateValue> StateValues { get; set; }

        public AlzBuddyDB() : base() { }
    }
}
