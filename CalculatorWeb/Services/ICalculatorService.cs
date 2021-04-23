using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWeb.Services
{
    public interface ICalculatorService
    {
        Task<int> Add(int start, int amount);
        Task<int> Subtract(int start, int amount);
        Task<int> Multiply(int start, int by);
        Task<int> Divide(int start, int by);
    }
}
