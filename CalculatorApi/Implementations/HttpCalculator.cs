using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi.Implementations
{
    public class HttpCalculator : ISimpleCalculator
    {
        private readonly string _host;
        private readonly HttpClient _client;
        private readonly IDiagnostic _diagnostic;

        public HttpCalculator(IDiagnostic diagnostic)
        {
            _diagnostic = diagnostic;
            _host = "https://localhost:44331/calculator";
            _client = new HttpClient();
        }

        public int Add(int start, int amount)
        {
            string input = start + "," + amount;

            //Send to web server via HttpClient
            string connection = _host + "/add/" + input;
            try { _diagnostic.Log($"Calculating {start} + {amount} using web API."); }
            catch { }

            return GetRequest(connection);
        }

        public int Divide(int start, int by)
        {
            string input = start + "," + by;

            //Send to web server via HttpClient
            string connection = _host + "/divide/" + input;
            try { _diagnostic.Log($"Calculating {start} / {by} using web API."); }
            catch { }

            return GetRequest(connection);
        }

        public int Multiply(int start, int by)
        {
            string input = start + "," + by;

            //Send to web server via HttpClient
            string connection = _host + "/multiply/" + input;
            try { _diagnostic.Log($"Calculating {start} * {by} using web API."); }
            catch { }

            return GetRequest(connection);
        }

        public int Subtract(int start, int amount)
        {
            string input = start + "," + amount;

            //Send to web server via HttpClient
            string connection = _host + "/subtract/" + input;
            try { _diagnostic.Log($"Calculating {start} - {amount} using web API."); }
            catch { }

            return GetRequest(connection);
        }

        private int GetRequest(string connection)
        {
            try
            {
                string response = Task.Run(() => _client.GetStringAsync(connection)).Result;
                try { _diagnostic.Log($"Calculation successful, result = {response}"); }
                catch { }
                return int.Parse(response);
            }
            catch
            {
                //return 0;
                try { _diagnostic.Log($"Calculation failed."); }
                catch { }
                throw new HttpRequestException("There was an error connecting to the server, it may be offline.");
            }
        }
    }
}
