using ExpressionEvaluator.Symbols;

namespace ExpressionEvaluator.Tokens
{
    internal class MultiplyToken : OperatorToken
    {
        protected override int Precedence => 2;

        protected override NonTerminalSymbol GetSymbol()
        {
            return new MultiplySymbol();
        }
    }
}