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
            while (true)
            {
                var input = Console.ReadLine();
                var result = calculator.CalculateResult(input, DateTime.Now);
                Console.WriteLine(result);

            }

        }
    }
}
