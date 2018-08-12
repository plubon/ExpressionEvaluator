using ExpressionEvaluator.Symbols;

namespace ExpressionEvaluator.Tokens
{
    internal class PlusToken : OperatorToken
    {
        protected override int Precedence => 1;

        protected override NonTerminalSymbol GetSymbol()
        {
            return new PlusSymbol();
        }
    }
}
