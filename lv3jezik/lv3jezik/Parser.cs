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
        char separator = ' ';
        char[] operators = { '+', '-', '*', '/', '=', '#' };
        char comment = '!';

        /*
         * IMPORTANT TO DO: u slučaju pojave normalnog operatora i endline operatora '#', endline se neće pojaviti
         * jer će ga promatrati kao ulančavanje opet. Potrebno popraviti to, možda najbolje novom varijablom endline
         * poput trenutnih separator i comment. Imati u vidu popraviti i sve što ta izmjena povlači za sobom
         */

        List<VariableData> variables;
        //TODO
        /*
         * 1 ukloniti separatore ako se pojavljuju između identifikatora ("c ab b" --> "cabb")
         * 2 pobrojati varijable i spremiti u listu, metoda CountVariables()
         * 3 napraviti metodu CheckForVariable(String variable) koja prolazi kroz listu i vraća je li pronašla varijablu iz argumenta
         * 4 možda: ukloniti višestruki separator, da bude maksimalno 1 razmak a ne      6 njih u ispisu
         */
        public Parser()
        {
            this.variables = new List<VariableData>();
        }
        public List<char> ReturnValidElements(String input)
        {
            List<char> tempList = new List<char>();
            foreach (char c in input)
            {
                if (identificators.Contains(c)  || operators.Contains(c) || comment == c)
                {
                    tempList.Add(c);
                }
            }
            return tempList;
        }
        //ova metoda odmah napravi konacni izraz
        public List<char> RemoveMultipleOperators(List<char> list)
        {
            List<char> tempList = new List<char>();
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
        public string GetCharTypes(char c)
        {
            if (operators.Contains(c))
                return ("(" + c + ", operator)");

            else if (identificators.Contains(c))
                return ("(" + c + ", identificator)");

            else if (separator == c)
                return ("(" + c + ", separator)");

            else
                return ("(" + c + ", comment)");
        }
        public void ListCharTypes(List<char> list)
        {
            foreach(char c in list)
                Console.WriteLine(GetCharTypes(c));
        }
        public void CountVariables(List<char> expression)
        {
            bool foundMatch = false;
            List<char> currentVariable;

            for(int i = 0; i < expression.Count;)
            {
                if (identificators.Contains(expression[i]))
                {
                    currentVariable = new List<char>();
                    currentVariable.Add(expression[i]);

                    int j = 1;

                    while (identificators.Contains(expression[i+j])) {
                        currentVariable.Add(expression[i + j]);
                        j++;
                    }
                    //TODO
                    /*
                     * 5 extract string from currentVariable list
                     * 6 make new method CheckForVariable(String variable) to check if variable has already been used
                     * 7 save result in foundMatch
                     * 8 if(!foundMatch) -> create new VariableData class with currentVariable and add it to the variables list
                     */
                    i += j;
                }
                else i++;
            }
        }
    }

    class VariableData
    {
        string variable;
        int repetitionCount;
        public VariableData(String variable)
        {
            this.variable = variable;
            repetitionCount = 0;
        }
        public string GetVariable() => this.variable;
        public void IncrementRepetition()
        {
            this.repetitionCount++;
        }
    }
}
