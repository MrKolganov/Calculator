using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorService.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculatorService.Controllers.Tests
{
    [TestClass]
    public class CalculatorServiceTest
    {
        [TestMethod]
        public void SubtractTest()
        {
            int x = 10;
            int y = 5;
            double expected = 5;

            CalculatorController calculatorController = new CalculatorController();
            double actual = calculatorController.Subtract(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest()
        {
            int x = 5;
            int y = 15;
            double expected = 20;

            CalculatorController calculatorController = new CalculatorController();
            double actual = calculatorController.Add(x, y);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void DividetTest()
        {
            int x = 10;
            int y = 5;

            CalculatorController calculatorController = new CalculatorController();
            var result = calculatorController.Divide(x, y);

            Assert.IsType<OkObjectResult>(result);
        }

        [TestMethod]
        public void DivideResultTest()
        {
            int x = 10;
            int y = 5;
            double expected = 2;

            CalculatorController calculatorController = new CalculatorController();
            var result = calculatorController.Divide(x, y) as OkObjectResult;

            Assert.Equal(expected, result.Value);
        }
        
        [TestMethod]
        public void MultiplyTest()
        {
            int x = 10;
            int y = 5;
            double expected = 50;

            CalculatorController calculatorController = new CalculatorController();
            double actual = calculatorController.Multiply(x, y);

            Assert.AreEqual(expected, actual);
        }
    }
}