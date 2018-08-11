namespace ExpressionEvaluator.Symbols
{
    public abstract class AbstractSymbol
    {
        internal abstract void Evaluate(EvaluationContext context);
    }
}