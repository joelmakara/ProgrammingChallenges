using System.Collections.Generic;

namespace web_calculator_api.Domain
{
    public class Calculate
    {
        public static string Process(string input)
        {
            if ( string.IsNullOrWhiteSpace(input) || !containsOperator(input))
            {
                return input;
            }

            var x = new List<int>();
            int k = x.Count();

           string.Equals("", "", System.StringComparison.)

            var operands = splitOperands(input);

            if(canEvaluate(operands))
            {
                result = evaluate(operands);
            }
            var output = 

            return string.Empty;
        }
    }
}