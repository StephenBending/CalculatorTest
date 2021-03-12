using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;

namespace CalculatorApi
{
    public interface ISimpleCalculator
    {
        int Add(int start, int amount);
        int Subtract(int start, int amount);
        int Multiply(int start, int by);
        int Divide(int start, int by);
    }

    public class SimpleCalculator : ISimpleCalculator
    {
        private IDiagnostic _diagnostic;

        public SimpleCalculator(IDiagnostic diagnostic)
        {
            _diagnostic = diagnostic;
        }

        private void Log(string log)
        {

        }

        public int Add(int start, int amount)
        {
            try { _diagnostic.Log($"Calculating {start} + {amount}"); }
            catch { }

            return start + amount;
        }

        public int Subtract(int start, int amount)
        {
            try { _diagnostic.Log($"Calculating {start} - {amount}"); }
            catch { }

            return start - amount;
        }

        public int Divide(int start, int by)
        {
            try { _diagnostic.Log($"Calculating {start} / {by}"); }
            catch { }

            return start /by;
        }

        public int Multiply(int start, int by)
        {
            try { _diagnostic.Log($"Calculating {start} * {by}"); }
            catch { }

            return start *by;
        }
    }

    public interface IDiagnostic
    {
        void Log(string log);
    }

    public class DiagnosticConsole : IDiagnostic
    {
        Logger _logger;
        public DiagnosticConsole()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        public void Log(string log)
        {
            _logger.Information(log);
        }
    }

    public class NullDiagnostic : IDiagnostic
    {
        public void Log(string log)
        {
            
        }
    }
}
