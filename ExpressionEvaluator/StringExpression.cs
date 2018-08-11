using ExpressionEvaluator.Symbols;
using ExpressionEvaluator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionEvaluator
{
    public class StringExpression
    {

        private ParsingContext Context {get; set;}

        public StringExpression(string input)
        {
            Context = new ParsingContext(input);
        }

        private AbstractToken ReadToken()
        {
            if(Char.IsDigit(Context.Input[0]))
            {
                if (Context.LastRead == LastToken.Value)
                    throw new ArgumentException("Input is not a valid expression");
                int val = Context.ReadNumber();
                return new ValueToken(val);
            }
            if("+-*/".Contains(Context.Input[0]))
            {
                if(Context.LastRead == LastToken.Operator)
                    throw new ArgumentException("Input is not a valid expression");
                char operatorChar = Context.ReadOperator();
                switch(operatorChar)
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
                        throw new ArgumentException("Invalid character in expression string");
                }
            }
            else
            {
                throw new ArgumentException("Invalid character in expression string");
            }
        }

        public List<AbstractSymbol> Parse()
        {
            while(Context.Input.Length > 0)
            {
                var token = ReadToken();
                token.Parse(Context);
            }
            while (Context.Operators.TryPop(out NonTerminalSymbol op))
                Context.Output.Add(op);
            return Context.Output;
        }
    }
}