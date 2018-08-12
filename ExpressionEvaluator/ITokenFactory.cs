using ExpressionEvaluator.Tokens;

namespace ExpressionEvaluator
{
    public interface IOperatorTokenFactory
    {
        string OperatorsString { get; }

        AbstractToken ProduceOperator(char operatorChar);
        AbstractToken ProduceValue(int val);
    }
}