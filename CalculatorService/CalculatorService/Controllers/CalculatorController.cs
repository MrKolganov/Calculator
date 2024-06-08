using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Diagnostics;

namespace CalculatorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        [HttpGet("multiply/{num1}/{num2}")]
        public double Multiply(double num1, double num2)
        {
            Console.WriteLine($"{num1} * {num2}");
            return num1 * num2;
        }

        [HttpGet("divide/{num1}/{num2}")]
        public IActionResult Divide(double num1, double num2)
        {
            try
            { 
                Console.WriteLine($"{num1} / {num2}");
                return Ok(num1 / num2);
            }
            catch (DivideByZeroException dz)
            {
                return BadRequest("На ноль делить нельзя");
            }
        }

        [HttpGet("add/{num1}/{num2}")]
        public double Add(double num1, double num2)
        {
            Console.WriteLine($"{num1} + {num2}");
            return num1 + num2;
        }

        [HttpGet("subtract/{num1}/{num2}")]
        public double Subtract(double num1, double num2)
        {
            Console.WriteLine($"{num1} - {num2}");
            return num1 - num2;
        }
    }
}
