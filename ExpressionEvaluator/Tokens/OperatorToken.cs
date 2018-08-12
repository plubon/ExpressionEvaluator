using ExpressionEvaluator.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionEvaluator.Tokens
{
    public abstract class OperatorToken : AbstractToken
    {

        protected abstract int Precedence { get;}

        protected abstract NonTerminalSymbol GetSymbol();

        internal override void Parse(ParsingContext context)
        {
            bool keepPopping = true;
            while(keepPopping)
            {
                if(context.Operators.TryPeek(out NonTerminalSymbol top))
                {
                    if (top.Precedence >= Precedence)
                    {
                        context.Output.Add(context.Operators.Pop());
                    }
                    else
                        keepPopping = false;
                }
                else
                {
                    keepPopping = false;
                }
            }
            context.Operators.Push(GetSymbol());
        }
    }
}
