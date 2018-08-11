namespace ExpressionEvaluator.Symbols
{
    internal class ValueSymbol : AbstractSymbol
    {
        private double Value { get; set; }

        public ValueSymbol(int value)
        {
            this.Value = value;
        }

        public ValueSymbol(double value)
        {
            this.Value = value;
        }

        internal override void Evaluate(EvaluationContext context)
        {
            context.Stack.Push(this);
        }

        public double GetValue()
        {
            return Value;
        }
    }
}