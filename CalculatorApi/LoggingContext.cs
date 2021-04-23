using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CalculatorApi
{
    public partial class LoggingContext : DbContext
    {
        public LoggingContext()
            : base("name=LoggingContext")
        {
        }

        public virtual DbSet<CalcLog> CalcLogs { get; set; }
        //public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalcLog>()
                .Property(e => e.LogInfo)
                .IsFixedLength();
        }
    }
}
