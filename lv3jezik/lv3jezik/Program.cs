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

            validElements = parser.returnValidElements("abbbbb++++. ..... .c1njd=a!");
            Console.WriteLine(validElements.ToArray());
            validElements2 = parser.removeMultipleOperators(validElements);
            Console.WriteLine(validElements2.ToArray());
            parser.func(validElements2);
            System.Threading.Thread.Sleep(5000);
            
        }

    }
}
