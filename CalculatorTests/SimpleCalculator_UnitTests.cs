using System;
using CalculatorApi;
using Moq;
using NUnit.Framework;
using Serilog;
using Serilog.Core;

namespace CalculatorTests
{
    public class SimpleCalculator_UnitTests
    {
        private ISimpleCalculator generateCalculator()
        {
            return new SimpleCalculator(new DiagnosticConsole());
        }

        //use UnitUnderTest_Scenario_ExpectedOutcome naming scheme
        [TestCase(1, 1, 2)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 5, 10)]
        [TestCase(6, 7, 13)]
        [TestCase(92, 36, 128)]
        [TestCase(0, 0, 0)]
        [TestCase(0, -1, -1)]
        [TestCase(90, -50, 40)]
        [TestCase(3, -5, -2)]
        [TestCase(100, 3, 103)]
        public void Add_Integers_ReturnsSum(int start, int amount, int expectedResult)
        {
            ISimpleCalculator calc = generateCalculator();
            int result = calc.Add(start, amount);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 0, 0)]
        [TestCase(5, 5, 0)]
        [TestCase(6, 3, 3)]
        [TestCase(5, -5, 10)]
        [TestCase(1, 5, -4)]
        [TestCase(-6, 3, -9)]
        [TestCase(-4, -8, 4)]
        public void Subtract_Integers_ReturnsSubtraction(int start, int amount, int expectedResult)
        {
            ISimpleCalculator calc = generateCalculator();
            int result = calc.Subtract(start, amount);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 0)]
        [TestCase(-5, 0, 0)]
        [TestCase(9, 1, 9)]
        [TestCase(8, 2, 16)]
        [TestCase(7, -2, -14)]
        [TestCase(-2, -2, 4)]
        [TestCase(100, 100, 10000)]
        public void Multiply_Integers_ReturnsMultiplication(int start, int by, int expectedResult)
        {
            ISimpleCalculator calc = generateCalculator();
            int result = calc.Multiply(start, by);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(5, 5, 1)]
        [TestCase(8, 2, 4)]
        [TestCase(10, -2, -5)]
        [TestCase(-6, 3, -2)]
        [TestCase(-8, -4, 2)]
        public void Divide_Integers_ReturnsDivision(int start, int by, int expectedResult)
        {
            ISimpleCalculator calc = generateCalculator();
            int result = calc.Divide(start, by);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(5,0)]
        [TestCase(0,0)]
        [TestCase(-7,0)]
        public void Divide_DivideByZero_DivideByZeroException(int start, int by)
        {
            ISimpleCalculator calc = generateCalculator();
            Assert.Throws<DivideByZeroException>(() => calc.Divide(5, 0));
        }

        [Test]
        public void Log_LogString_LogIsCalled()
        {
            Mock<IDiagnostic> mockDiag = new Mock<IDiagnostic>();
            SimpleCalculator calc = new SimpleCalculator(mockDiag.Object);
            var result = calc.Add(5,5);
            mockDiag.Verify(m => m.Log(It.IsAny<string>()), Times.Once);
        }
    }
}
