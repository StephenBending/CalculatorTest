using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class IDiagnosticEF : IDiagnostic
    {
        public void Log(string log)
        {
            using (var db = new LoggingContext())
            {
                var Log = new CalcLog() { LogInfo = log,
                                          Date = System.DateTime.UtcNow};

                db.CalcLogs.Add(Log);
                db.SaveChanges();
            }
        }
    }
}
