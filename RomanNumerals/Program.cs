using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new RomanNumeralsCalculator();
            var result = calculator.Calculate(555);
            Console.WriteLine(result);
        }
    }
}
