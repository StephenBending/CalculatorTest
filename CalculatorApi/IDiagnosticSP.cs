using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class IDiagnosticSP : IDiagnostic
    {
        public void Log(string log)
        {
            string connectionString = "data source=.\\SQLExpress;initial catalog=CalcLogging;user id=sa;password=sa;MultipleActiveResultSets=True;App=EntityFramework";


            using (var conn = new SqlConnection(connectionString))
            {
                using (var comm = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        comm.CommandText = "INSERT INTO CalcLogs (LogInfo, Date) VALUES (@log, @dateTime)";
                        comm.Parameters.AddWithValue("@log", log);
                        comm.Parameters.AddWithValue("@dateTime", System.DateTime.UtcNow);
                        comm.ExecuteNonQuery();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
