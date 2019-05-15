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
                
                if (!isValid(input))
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

        private static bool isValid(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            
            decimal operand = 0m;
            var splitList = input.Split(Operators.AllOperators.ToArray()).ToList();

            foreach( var op in splitList)
            {
                if (!decimal.TryParse(op, out operand))
                {
                    return false;
                }
            }

            return true;
        }

        private static decimal evaluate(string input)
        {
            decimal result;
            if (Operators.OperatorCount(input) == 0 && decimal.TryParse(input, out result))
            {
                return result;
            }

            var components = splitOperands(input);

            decimal leftOperand = 0, rightOperand = 0;

            var _operator = components[1];

            if (decimal.TryParse(components[0], out leftOperand) &&
               decimal.TryParse(components[2], out rightOperand))
            {
                return compute(components);
            }


            leftOperand = evaluate(components[0]);
            rightOperand = evaluate(components[2]);

            return compute(new List<string> { leftOperand.ToString(), _operator, rightOperand.ToString() });
            
        }               

        private static decimal compute(List<string> components)
        {
            var result = 0m;
            var leftOperand = decimal.Parse(components[0]);
            var _operator = char.Parse(components[1]);
            var rightOperand = decimal.Parse(components[2]);

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
            var splitList = input.Split(operatorToSplitBy, 2).ToList();

            return new List<string> { splitList[0], operatorToSplitBy.ToString(), splitList[1] };
        }

        
    }
}       