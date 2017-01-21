using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Ohce!!");
            Console.WriteLine("*******************");
            var calculator = new OhceCalculator();
            var continueProgram = true;
            while (continueProgram)
            {
                var input = Console.ReadLine();
                var results = calculator.CalculateResult(input, DateTime.Now);
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                    if (result.Contains(calculator.Bye))
                    {
                        continueProgram = false;
                    }
                }                
            }
            Console.WriteLine("*******************");
            Console.WriteLine("Press any key to close the app");
            Console.ReadLine();

        }
    }
}
