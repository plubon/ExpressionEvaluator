using ExpressionEvaluator.Symbols;

namespace ExpressionEvaluator.Tokens
{
    internal class ValueToken : AbstractToken
    {
        private int Value { get; set; }

        public ValueToken(int val)
        {
            this.Value = val;
        }

        internal override void Parse(ParsingContext context)
        {
            context.Output.Add(new ValueSymbol(Value));
        }
    }
}