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
        char[] operators = { '+', '-', '*', '/', '=', '#'};
        char comment = '!';

        List<VariableData> variables;
        //TODO
        /*
         * 1 ukloniti separatore ako se pojavljuju između identifikatora ("c ab b" --> "cabb")
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
                if (identificators.Contains(c) || operators.Contains(c) || comment == c)
                {
                   
                    tempList.Add(c);
                }
            }
            return tempList;
        }
        public List<char> RemoveMultipleOperators(List<char> list)
        {
            List<char> tempList = new List<char>();
            int i;
            int index;
            int count;

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

        public List<char> getFinalExpression(List<char> list)
        {
            List<char> tempList = new List<char>(list);
            int index;
            int count;
            int range;
            count = list.Count();
            index = list.IndexOf('#');
            range = count - index;
            tempList.RemoveRange(index, range);
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
            foreach (char c in list)
                Console.WriteLine(GetCharTypes(c));
        }

        public void CountVariables(List<char> expression)
        {

            bool foundMatch;
            List<char> currentVariable = new List<char>();

            for (int i = 0; i < expression.Count; i++)
            {
                foundMatch = false;
                foreach (VariableData variable in variables)
                {
                    if (variable.GetVariable() == expression[i])
                    {
                        variable.IncrementRepetition();
                        foundMatch = true;
                        break;
                    }
                }
                if (!foundMatch)
                {
                    VariableData temp = new VariableData(expression[i]);
                    variables.Add(temp);
                }

            }

            
        }
        public string ConstructOutputString(List<char> expression)
        {
            int identificatorCount = 0;
            int operatorCount = 0;
            int commentCount = 0;

            string temp = "";

            foreach(VariableData var in variables)
            {
                if (identificators.Contains(var.GetVariable()))
                {
                    identificatorCount++;
                }
                else if(operators.Contains(var.GetVariable()))
                {
                    operatorCount++;
                }
                else if (var.GetVariable() == comment)
                {
                    commentCount++;
                }
            }
            StringBuilder builder = new StringBuilder();

            int i = 0;

            builder.Append("\nidentificators [" + identificatorCount + "]: ");
            foreach (VariableData var in variables)
            {
                if (identificators.Contains(var.GetVariable()))
                {
                    builder.Append("'" + variables[i].GetVariable() + "'[" + variables[i].GetRepetitionCount() + "] ");
                    
                }
                i++;
            }
            i = 0;
            builder.Append("\noperators [" + operatorCount + "]: ");
            foreach (VariableData var in variables)
            {
                if (operators.Contains(var.GetVariable()))
                {
                    builder.Append("'" + variables[i].GetVariable() + "'[" + variables[i].GetRepetitionCount() + "] ");
                    
                }
                i++;
            }

            i = 0;
            builder.Append("\ncomments [" + commentCount + "]: ");
            foreach (VariableData var in variables)
            {
                if (comment == var.GetVariable())
                {
                    builder.Append("'" + variables[i].GetVariable() + "'[" + variables[i].GetRepetitionCount() + "] ");

                }
                i++;
            }

            return builder.ToString();
        }

        class VariableData
        {
            char variable;
            int repetitionCount;
            public VariableData(char variable)
            {
                this.variable = variable;
                repetitionCount = 1;
            }
            public char GetVariable() => this.variable;
            public int GetRepetitionCount() => this.repetitionCount;
            public void IncrementRepetition()
            {
                this.repetitionCount++;
            }

        }
    }
}
