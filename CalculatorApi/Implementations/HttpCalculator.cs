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

        public HttpCalculator()
        {
            _host = "https://localhost:44331/calculator";
            _client = new HttpClient();
        }

        public int Add(int start, int amount)
        {
            string input = start + "," + amount;

            //Send to web server via HttpClient
            string connection = _host + "/add/" + input;

            return GetRequest(connection);
        }

        public int Divide(int start, int by)
        {
            string input = start + "," + by;

            //Send to web server via HttpClient
            string connection = _host + "/divide/" + input;

            return GetRequest(connection);
        }

        public int Multiply(int start, int by)
        {
            string input = start + "," + by;

            //Send to web server via HttpClient
            string connection = _host + "/multiply/" + input;

            return GetRequest(connection);
        }

        public int Subtract(int start, int amount)
        {
            string input = start + "," + amount;

            //Send to web server via HttpClient
            string connection = _host + "/subtract/" + input;

            return GetRequest(connection);
        }

        private int GetRequest(string connection)
        {
            try
            {
                string response = Task.Run(() => _client.GetStringAsync(connection)).Result;
                return int.Parse(response);
            }
            catch
            {
                //return 0;
                throw new HttpRequestException("There was an error connecting to the server, it may be offline.");
            }
        }
    }
}
