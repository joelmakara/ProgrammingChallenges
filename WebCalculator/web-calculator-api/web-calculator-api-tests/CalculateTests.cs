using System;
using web_calculator_api.Domain;
using Xunit;

namespace web_calculator_api_tests
{
    public class CalculateTests
    {
        [Fact]
        public void CalculateYieldsEmptyStringWithEmptyInput()
        {
            var inputEquation = string.Empty;
            var result = Calculate.Process(inputEquation);
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void CalculateYieldsCorrectResultWithSimpleValidInput()
        {
            var inputEquation = "5.5 + 6.2";
            var result  = Calculate.Process(inputEquation);
            Assert.Equal("11.7", result);
        }

        [Fact]
        public void CalculateYieldsCorrectResultWithFairlyComplexInput()
        {
            var inputEquation = "5 + 6 * 8";
            var result = Calculate.Process(inputEquation);
            Assert.Equal("53", result);
        }

        [Fact]
        public void CalculateYieldsCorrectResultWithComplexInput()
        {
            var inputEquation = "5 + 6 * 8 / 2 - 7 + 21 * 4 + 14 - 5";
            var result = Calculate.Process(inputEquation);
            Assert.Equal("-81", result);
        }
    }
}
