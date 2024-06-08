using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorClient
{
    internal class Program
    {
        private const string baseUrl = "https://localhost:7273/api/Calculator";

        static async Task Main(string[] args)
        {
            double num1, num2;
            GetNumberInput(out num1, "Введите первое число: ");
            GetNumberInput(out num2, "Введите второе число: ");

            Console.WriteLine("Выберите операцию (1 - умножение, 2 - деление, 3 - сложение, 4 - вычитание): ");
            if (!int.TryParse(Console.ReadLine(), out int operation))
            {
                Console.WriteLine("Неверный формат операции.");
                return;
            }

            string result = await Calculate(operation, num1, num2);
            Console.WriteLine($"Результат: {result}");
            Console.ReadKey();
        }

        private static void GetNumberInput(out double num, string message)
        {
            Console.WriteLine(message);
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Неверный формат числа. Пожалуйста, введите число:");
            }
        }

        private static async Task<string> Calculate(int operation, double num1, double num2)
        {
            using var client = new HttpClient();

            string operationName;
            switch (operation)
            {
                case 1: operationName = "multiply"; break;
                case 2: operationName = "divide"; break;
                case 3: operationName = "add"; break;
                case 4: operationName = "subtract"; break;
                default:
                    Console.WriteLine("Неверная операция");
                    return "Ошибка: Неверная операция";
            }

            string url = $"{baseUrl}/{operationName}/{num1}/{num2}";
            HttpResponseMessage response;

            try
            {
                response = await client.GetAsync(url);
            }
            catch
            {
                return "Ошибка подключения к серверу";
            }

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Ошибка выполнения запроса";
            }
        }
    }
}