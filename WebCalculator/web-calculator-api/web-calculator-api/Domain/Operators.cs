using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_calculator_api.Domain
{
    public class Operators
    {
        public  static List<char> AllOperators = new List<char> { Add, Subtract, Multiply, Divide };
        public const char Add = '+';
        public const char Subtract = '-';
        public const char Multiply = '*';
        public const char Divide = '/';

        public static char GetLowestPrecedence(string input)
        {
            if(input.Contains(Subtract))
            {
                return Subtract;
            }

            if (input.Contains(Add))
            {
                return Add;
            }

            if (input.Contains(Multiply))
            {
                return Multiply;
            }

            return Divide;            
        }

        public static char GetHighestPrecedence(string input)
        {
            if (input.Contains(Divide))
            {
                return Divide;
            }

            if (input.Contains(Multiply))
            {
                return Multiply;
            }

            if (input.Contains(Add))
            {
                return Add;
            }

            return Subtract;
        }

        public static List<string> Split(string input)
        {
            input = input.Replace(" ", string.Empty);
            var components = new List<string>();
            var lastSplitIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var operand = string.Empty;
                if (AllOperators.Contains(input[i]) && i != lastSplitIndex)
                {
                    operand = input.Substring(lastSplitIndex, i - lastSplitIndex);
                    components.Add(operand);
                    components.Add(input[i].ToString());
                    lastSplitIndex = i + 1;
                }
            }

            if(lastSplitIndex < input.Length)
            {
                components.Add(input.Substring(lastSplitIndex, input.Length - lastSplitIndex));
            }

            return components;
        }

        public static int OperatorCount(string input)
        {
            var count = 0;
            foreach (var operand in AllOperators)
            {
                if (input.Contains(operand))
                {
                    count++;
                }
            }
            return count;
        }

        public static char GetFirstOperator(string input)
        {
            foreach (var operand in AllOperators)
            {
                if (input.Contains(operand))
                {
                    return operand;
                }
            }
            return ' ';
        }        
    }
}
