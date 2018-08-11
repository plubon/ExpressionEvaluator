using ExpressionEvaluator.Symbols;

namespace ExpressionEvaluator.Tokens
{
    internal class PlusToken : OperatorToken
    {
        protected override int Precedence => throw new System.NotImplementedException();

        protected override NonTerminalSymbol GetSymbol()
        {
            return new PlusSymbol();
        }
    }
}
