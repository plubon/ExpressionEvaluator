namespace ExpressionEvaluator.Tokens
{
    public abstract class AbstractToken
    {
        internal abstract void Parse(ParsingContext context);
    }
}