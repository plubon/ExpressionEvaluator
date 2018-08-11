using System;

namespace ExpressionEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter an expression.");
            var input = Console.ReadLine();
            StringExpression parser = new StringExpression(input);
            var rpn = parser.Parse();
            var evaluator = new ParsedExpression(rpn);
            Console.WriteLine(evaluator.Evaluate());
            Console.ReadLine();
        }
    }
}
