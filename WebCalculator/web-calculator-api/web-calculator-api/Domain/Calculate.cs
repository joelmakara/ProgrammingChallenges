using System;
using System.Collections.Generic;
using System.Linq;

namespace web_calculator_api.Domain
{
    public class Calculate
    {
        public static string Process(string input)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new CannnotEvaluateEpressionException();
                }                
                
                return evaluate(input).ToString();
            }
            catch (CannnotEvaluateEpressionException e)
            {
                return string.Empty;
            }
        }

        private static int evaluate(string input)
        {
            int result;
            if (Operators.OperatorCount(input) == 0 && Int32.TryParse(input, out result))
            {
                return result;
            }

            var components = splitOperands(input);

            int leftOperand = 0, 
                rightOperand = 0;

            var _operator = components[1];

            if (Int32.TryParse(components[0], out leftOperand) &&
               Int32.TryParse(components[2], out rightOperand))
            {
                return compute(components);
            }


            leftOperand = evaluate(components[0]);
            rightOperand = evaluate(components[2]);

            return compute(new List<string> { leftOperand.ToString(), _operator, rightOperand.ToString() });
            
        }               

        private static int compute(List<string> components)
        {
            var result = 0;
            var leftOperand = Int32.Parse(components[0]);
            var _operator = Char.Parse(components[1]);
            var rightOperand = Int32.Parse(components[2]);

            switch (_operator)
            {
                case Operators.Divide:
                    {
                        if (rightOperand != 0)
                        {
                            result = leftOperand / rightOperand;
                        }
                        else
                        {
                            throw new CannnotEvaluateEpressionException("Cannot divide by zero");
                        }
                    }
                    break;

                case Operators.Multiply: result = leftOperand * rightOperand; break;
                case Operators.Add: result = leftOperand + rightOperand; break;
                default: result = leftOperand - rightOperand; break;
            }
            return result;
        }
        

        private static List<string> splitOperands(string input)
        {
            char operatorToSplitBy = Operators.GetLowestPrecedence(input);
            var splitList = input.Split(operatorToSplitBy).ToList();

            return new List<string> { splitList[0], operatorToSplitBy.ToString(), splitList[1] };
        }

        
    }
}       