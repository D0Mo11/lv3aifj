using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv3jezik
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            List<char> validElements = new List<char>();
            List<char> validElements2 = new List<char>();
            List<char> validElements3 = new List<char>();

            validElements = parser.ReturnValidElements("ab!bb++++. ..... .c1njd=a#!bac");
            Console.Write("Input: ");
            Console.WriteLine(validElements.ToArray());

            validElements2 = parser.RemoveMultipleOperators(validElements);
            Console.Write("Removed concatenated operators: ");
            Console.WriteLine(validElements2.ToArray());

            validElements3 = parser.getFinalExpression(validElements2);
            Console.Write("Final Expression: ");
            Console.WriteLine(validElements3.ToArray());

            parser.ListCharTypes(validElements3);
            parser.CountVariables(validElements3);

            Console.WriteLine(parser.ConstructOutputString(validElements3));
            Console.ReadLine();
        }

    }
}
