namespace ExpressionEvaluator.Tokens
{
    internal abstract class AbstractToken
    {
        internal abstract void Parse(ParsingContext context);
    }
}