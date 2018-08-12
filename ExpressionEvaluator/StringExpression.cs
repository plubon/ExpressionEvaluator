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

        private IOperatorTokenFactory TokenFactory { get; set; }

        

        private bool IsOperatorNext() => TokenFactory.OperatorsString.Contains(Context.GetFirstChar());

        private bool IsDigitNext() => Char.IsDigit(Context.GetFirstChar());

        public StringExpression(string input, IOperatorTokenFactory resolver)
        {
            Context = new ParsingContext(input);
            TokenFactory = resolver;
        }

        private AbstractToken ReadToken()
        {
            if(IsDigitNext())
            {
                if (Context.LastRead == LastToken.Value)
                    throw new ArgumentException("Input is not a valid expression");
                int val = Context.ReadNumber();
                return TokenFactory.ProduceValue(val);
            }
            if(IsOperatorNext())
            {
                if(Context.LastRead == LastToken.Operator)
                    throw new ArgumentException("Input is not a valid expression");
                char operatorChar = Context.ReadOperator();
                return TokenFactory.ProduceOperator(operatorChar);
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
            if(Context.LastRead != LastToken.Value)
                throw new ArgumentException("Input is not a valid expression");
            while (Context.Operators.TryPop(out NonTerminalSymbol op))
                Context.Output.Add(op);
            return Context.Output;
        }
    }
}