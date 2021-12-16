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

            validElements = parser.ReturnValidElements("abbb++++. ..... .c1njd=a!");
            Console.WriteLine(validElements.ToArray());
            validElements2 = parser.RemoveMultipleOperators(validElements);
            Console.WriteLine(validElements2.ToArray());
            parser.ListCharTypes(validElements2);

            Console.ReadLine();
        }

    }
}
