﻿namespace ExpressionEvaluator.Symbols
{
    internal class MinusSymbol : NonTerminalSymbol
    {
        public override int Precedence => 1;

        public override ValueSymbol GetValue(ValueSymbol val_1, ValueSymbol val_2)
        {
            return new ValueSymbol(val_1.GetValue() - val_2.GetValue());
        }
    }
}