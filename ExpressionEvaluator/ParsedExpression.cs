using ExpressionEvaluator.Symbols;
using System.Collections.Generic;

namespace ExpressionEvaluator
{
    public class ParsedExpression
    {
        private EvaluationContext Context { get; set; }

        public ParsedExpression(List<AbstractSymbol> expression)
        {
            Context = new EvaluationContext(expression);
        }

        public double Evaluate()
        {
            foreach(var symbol in Context.Symbols)
                symbol.Evaluate(Context);
            return Context.GetResult();
        }
    }
}