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
