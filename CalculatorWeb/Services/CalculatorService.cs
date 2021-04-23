using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorApi;

namespace CalculatorWeb.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ISimpleCalculator _simpleCalculator;

        public CalculatorService(ISimpleCalculator simpleCalculator)
        {
            _simpleCalculator = simpleCalculator;
        }
        
        public async Task<int> Add(int start, int amount)
        {
            var response = await Task<int>.Run( () =>_simpleCalculator.Add(start, amount));

            return response;
        }

        public async Task<int> Divide(int start, int by)
        {
            var response = await Task<int>.Run(() => _simpleCalculator.Divide(start, by));

            return response;
        }

        public async Task<int> Multiply(int start, int by)
        {
            var response = await Task<int>.Run(() => _simpleCalculator.Multiply(start, by));

            return response;
        }

        public async Task<int> Subtract(int start, int amount)
        {
            var response = await Task<int>.Run(() => _simpleCalculator.Subtract(start, amount));

            return response;
        }
    }
}
