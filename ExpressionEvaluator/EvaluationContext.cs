using ExpressionEvaluator.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionEvaluator
{
    class EvaluationContext
    {
        public List<AbstractSymbol> Symbols { get; set; }
        public Stack<ValueSymbol> Stack { get; set; }

        public EvaluationContext(List<AbstractSymbol> expression)
        {
            Symbols = expression;
            Stack = new Stack<ValueSymbol>();
        }

        internal double GetResult()
        {
            return Stack.Pop().GetValue();
        }
    }
}
