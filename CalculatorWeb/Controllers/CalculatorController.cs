using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWeb.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        [Route("add/{input}")]
        public async Task<int> CalcAdd(string input)
        {
            Tuple<int, int> nums = Task.Run(() => processNumbers(input)).Result;

            var result = await _calculatorService.Add(nums.Item1, nums.Item2);
            
            return result;
        }

        [HttpGet]
        [Route("subtract/{input}")]
        public async Task<int> CalcSubtract(string input)
        {
            Tuple<int, int> nums = Task.Run(() => processNumbers(input)).Result;

            var result = await _calculatorService.Subtract(nums.Item1, nums.Item2);

            return result;
        }

        [HttpGet]
        [Route("multiply/{input}")]
        public async Task<int> CalcMultiply(string input)
        {
            Tuple<int, int> nums = Task.Run(() => processNumbers(input)).Result;

            var result = await _calculatorService.Multiply(nums.Item1, nums.Item2);

            return result;
        }

        [HttpGet]
        [Route("divide/{input}")]
        public async Task<int> CalcDivide(string input)
        {
            Tuple<int, int> nums = Task.Run(() => processNumbers(input)).Result;

            var result = await _calculatorService.Divide(nums.Item1, nums.Item2);

            return result;
        }



        private Tuple<int, int> processNumbers(string input)
        {
            string[] splitInput = input.Split(',');

            if (splitInput.Length == 2)
            {
                return Tuple.Create(int.Parse(splitInput[0]), int.Parse(splitInput[1]));
            }
            else
            {
                return Tuple.Create(0, 0);
            }
        }

        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
