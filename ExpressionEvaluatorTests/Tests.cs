using ExpressionEvaluator;
using System;
using Xunit;

namespace ExpressionEvaluatorTests
{
    public class Tests
    {
        [Theory]
        [InlineData("asdas")]
        [InlineData("2+3?")]
        [InlineData("2-4*=")]
        public void InvalidChar(string input)
        {
            StringExpression parser = new StringExpression(input, new TokenFactory());
            Assert.Throws<ArgumentException>(() => parser.Parse());
        }

        [Theory]
        [InlineData("")]
        [InlineData("2+4=")]
        [InlineData("2+4/3+15*")]
        [InlineData("2+4**3+15")]
        public void InvalidSyntax(string input)
        {
            StringExpression parser = new StringExpression(input, new TokenFactory());
            Assert.Throws<ArgumentException>(() => parser.Parse());
        }

        [Theory]
        [InlineData("22+32", 54d)]
        [InlineData("4+5*2", 14d)]
        [InlineData("4+5/2", 6.5d)]
        [InlineData("4+5/2-1", 5.5d)]
        [InlineData("44/11/4", 1)]
        [InlineData("1000/10+100*3", 400)]
        public void CorrectValue(string input, double value)
        {
            StringExpression parser = new StringExpression(input, new TokenFactory());
            var parsed = parser.Parse();
            var evaluator = new ParsedExpression(parsed);
            Assert.Equal(value, evaluator.Evaluate());
        }

        [Theory]
        [InlineData("5/0")]
        public void DivisionByZero(string input)
        {
            StringExpression parser = new StringExpression(input, new TokenFactory());
            var parsed = parser.Parse();
            var evaluator = new ParsedExpression(parsed);
            Assert.Throws<ArithmeticException>(() => evaluator.Evaluate());
        }
    }
}
