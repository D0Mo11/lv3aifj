using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv3jezik
{
    class Parser
    {
        char[] identificators = { 'a', 'b', 'c', 'd', 'e', 'A', 'B', 'C', 'D', 'E' };
        char separators = ' ';
        char[] operators = { '+', '-', '*', '/', '=' };
        char comment = '!';
        public List<char> returnValidElements(String input)
        {
            List<char> tempList = new List<char>();
            foreach (char c in input)
            {
                if (identificators.Contains(c) || separators == c || operators.Contains(c) || comment == c)
                {
                    tempList.Add(c);
                }
            }
            return tempList;
        }

        //ova metoda odmah napravi konacni izraz
        public List<char> removeMultipleOperators(List<char> list)
        {
            List<char> tempList = new List<char>();
            List<char> input = new List<char>(list);
            int i;

            for (i = 0; i < list.Count();)
            {
                if (!operators.Contains(list[i]))
                {
                    tempList.Add(list[i]);
                    i++;
                }
                else
                {
                    int j = 1;
                    tempList.Add(list[i]);
                    while (operators.Contains(list[i + j]))
                    {
                        j++;
                    }
                    i += j;
                }
            }
            return tempList;
        }

        public string getCharTypes(char c)
        {
            if (operators.Contains(c))
            {
                return ("("+c + ", operator)\n");
            }

            else if (identificators.Contains(c))
            {
                return ("(" + c + ", identificator)\n");
            }

            else if (separators == c)
            {
                return ("(" + c + ", separator)\n");
            }

            else 
            {
                return ("(" + c + ", comment)\n");
            }
        }

        public void func(List<char> list)
        {
            foreach(char c in list)
            {
                Console.WriteLine(getCharTypes(c));
            }
        }

    }
}
