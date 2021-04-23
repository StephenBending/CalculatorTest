using Serilog;
using Serilog.Core;

namespace CalculatorApi
{
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
}
