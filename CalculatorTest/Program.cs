using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CalculatorApi;

namespace CalculatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<DiagnosticConsole>().As<IDiagnostic>(); //Outputs to Console
            builder.RegisterType<NullDiagnostic>().As<IDiagnostic>();      //Null, does not output at all

            builder.RegisterType<SimpleCalculator>().As<ISimpleCalculator>();
            var container = builder.Build();
            ISimpleCalculator calc = container.Resolve<ISimpleCalculator>();//new SimpleCalculator();

            string operation;
            Tuple<int, int> numbers;
            int result;
            var validInputs = new List<string> { "a", "s", "m", "d" };

            while (true)
            {
                Console.WriteLine($"\nPlease select an operation: Add (a), Subtract (s), Multiply (m), Divide (d)" +
                    $"\nTo exit type \"exit\"");
                operation = Console.ReadLine();

                if(operation == "exit")
                {
                    break;
                }

                if (validSelection(operation, validInputs))
                {
                    Console.WriteLine("\nPlease enter two number seperated by a comma (ex. 5,6):");
                    numbers = processNumbers(Console.ReadLine());
                    result = processOperation(operation, numbers, calc);
                    Console.WriteLine($"\nThe result of {numbers.Item1} {operation} {numbers.Item2} is {result}");
                }
                else
                {
                    Console.WriteLine("That is not a valid input\n");
                }
            }
        }

        private static int processOperation(string operation, Tuple<int, int> numbers, ISimpleCalculator calc)
        {
            switch (operation)
            {
                case "a":
                    return calc.Add(numbers.Item1,numbers.Item2);
                case "s":
                    return calc.Subtract(numbers.Item1, numbers.Item2);
                case "m":
                    return calc.Multiply(numbers.Item1, numbers.Item2);
                case "d":
                    return calc.Divide(numbers.Item1, numbers.Item2);
                default:
                    return 0;
            }
        }

        private static bool validSelection(string input, List<string> validInputs)
        {
            if (validInputs.Contains(input)) return true;
            else return false;
        }

        private static Tuple<int, int> processNumbers(string input)
        {
            string[] splitInput = input.Split(',');

            if (splitInput.Length == 2)
            {
                return Tuple.Create(int.Parse(splitInput[0]), int.Parse(splitInput[1]));
            }
            else
            {
                return Tuple.Create(0,0);
            }
        }
    }
}
