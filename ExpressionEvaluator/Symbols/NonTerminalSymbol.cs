namespace ExpressionEvaluator.Symbols
{
    internal abstract class NonTerminalSymbol : AbstractSymbol
    {
        public abstract int Precedence { get; }

        public abstract ValueSymbol GetValue(ValueSymbol val_1, ValueSymbol val_2);

        internal override void Evaluate(EvaluationContext context)
        {
            var val_2 = context.Stack.Pop();
            var val_1 = context.Stack.Pop();
            context.Stack.Push(GetValue(val_1, val_2));
        }
    }
}