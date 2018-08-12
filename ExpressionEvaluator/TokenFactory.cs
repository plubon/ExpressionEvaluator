using ExpressionEvaluator.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionEvaluator
{
    public class TokenFactory : IOperatorTokenFactory
    {

        public string OperatorsString => " + -*/ ";

        public AbstractToken ProduceOperator(char operatorChar)
        {
            switch (operatorChar)
            {
                case '+':
                    return new PlusToken();
                case '-':
                    return new MinusToken();
                case '*':
                    return new MultiplyToken();
                case '/':
                    return new DivideToken();
                default:
                    throw new ArgumentException("Character is not a valid operator");
            }
        }

        public AbstractToken ProduceValue(int val)
        {
            return new ValueToken(val);
        }
    }
}
