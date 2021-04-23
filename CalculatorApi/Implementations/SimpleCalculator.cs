using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{

    public class SimpleCalculator : ISimpleCalculator
    {
        private IDiagnostic _diagnostic;

        public SimpleCalculator(IDiagnostic diagnostic)
        {
            _diagnostic = diagnostic;
        }

        /*
        private void Log(string log)
        {

        }*/

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
}
