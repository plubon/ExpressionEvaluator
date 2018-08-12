using System;

namespace ExpressionEvaluator.Symbols
{
    internal class DivideSymbol : NonTerminalSymbol
    {
        public override int Precedence => 2;

        public override ValueSymbol GetValue(ValueSymbol val_1, ValueSymbol val_2)
        {
            if (val_2.GetValue() == 0)
                throw new ArithmeticException("Division by zero.");
            return new ValueSymbol(val_1.GetValue() / val_2.GetValue());
        }
    }
}