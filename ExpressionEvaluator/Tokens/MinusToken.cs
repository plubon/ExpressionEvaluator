using ExpressionEvaluator.Symbols;

namespace ExpressionEvaluator.Tokens
{
    internal class MinusToken : OperatorToken
    {
        protected override int Precedence => 1;

        protected override NonTerminalSymbol GetSymbol()
        {
            return new MinusSymbol();
        }
    }
}