using System;
using System.Collections.Generic;
using web_calculator_api.Domain;
using Xunit;

namespace web_calculator_api_tests
{
    public class OperatorTests
    {
        [Fact]
        public void OperatorSplitReturnEmptyListForEmptyInput()
        {
            var inputEquation = string.Empty;
            var result = Operators.Split(inputEquation);
            Assert.Equal(new List<string>(), result);
        }

        [Fact(Skip = "No longer implementing Exception")]
        public void OperatorSplitThrowsExceptionForMalformedInput()
        {
            var inputEquation = string.Empty;
            Assert.Throws<InvalidOperationException>(() => Operators.Split(inputEquation));
        }

        [Fact]
        public void OperatorSplitReturnsThreeElementsForSimpleExpressionWithOneOPerator()
        {
            var inputEquation = "5+6";
            var result = Operators.Split(inputEquation);
            Assert.Equal(3, result.Count);
        }


        [Fact]
        public void OperatorSplitReturnsSevenElementsForWellFormedExpressionWithThreeOPerators()
        {
            var inputEquation = "5+6*8-7";
            var result = Operators.Split(inputEquation);
            Assert.Equal(7, result.Count);
        }

        [Fact]
        public void OperatorSplitReturnsThirteenElementsForWellFormedExpressionWithThreeOPerators()
        {
            var inputEquation = "5.5+6.25*8-0+as-fd/4";
            var result = Operators.Split(inputEquation);
            Assert.Equal(13, result.Count);
        }

        [Fact]
        public void OperatorSplitReturnsTwoElementsForInputExpressionWithTwoOperators()
        {
            var inputEquation = "-*";
            var result = Operators.Split(inputEquation);
            Assert.Equal(2, result.Count);
        }
    }
}
