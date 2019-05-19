using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace web_calculator_api.Domain
{
    public class Calculate
    {
        public static string Process(string input)
        {
            input = input.Replace(" ", string.Empty);

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

        private static decimal evaluate(string input)
        {
            input = input.Replace(" ", string.Empty);

            decimal result;
            if (Operators.OperatorCount(input) == 0)
            {
                if (decimal.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    throw new CannnotEvaluateEpressionException();
                }
            }

            if (Operators.OperatorCount(input) == 1
                && Operators.GetFirstOperator(input).Equals('-')
                && decimal.TryParse(input, out result))
            {
                return result;
            }

            var _operator = Operators.GetHighestPrecedence(input);
            var splitList = Operators.Split(input);
            var operatorPos = splitList.IndexOf(_operator.ToString());
            decimal leftoperand = 0m, rightoperand = 0m;

            var expressionList = new List<string> {
                                                        splitList.ElementAt(operatorPos-1),
                                                        _operator.ToString(),
                                                        splitList.ElementAt(operatorPos+1)
                                                  };

            var expressionStr = string.Concat(expressionList);

            if (decimal.TryParse(splitList.First(), out leftoperand) &&
               decimal.TryParse(splitList.Last(), out rightoperand))
            {
                var regex = new Regex(Regex.Escape(expressionStr));
                input = regex.Replace(input, compute(expressionList).ToString(), 1);
            }

            return evaluate(input);
        }

        private static bool isValid(string input)
        {
            input = input.Replace(" ", string.Empty);

            if (string.IsNullOrWhiteSpace(input) ||
                Operators.AllOperators.Contains(input.First()) ||
                Operators.AllOperators.Contains(input.Last()))
            {
                return false;
            }

            decimal operand = 0m;
            var splitList = input.Split(Operators.AllOperators.ToArray()).ToList();

            foreach (var op in splitList)
            {
                if (!decimal.TryParse(op, out operand))
                {
                    return false;
                }
            }

            return true;
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


    }
}       