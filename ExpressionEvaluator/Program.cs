using System;

namespace ExpressionEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter an expression.");
            var input = Console.ReadLine();
            try
            {
                StringExpression parser = new StringExpression(input, new TokenFactory());
                var rpn = parser.Parse();
                var evaluator = new ParsedExpression(rpn);
                Console.WriteLine("Result:");
                Console.WriteLine(evaluator.Evaluate());
                Console.WriteLine("Press enter...");
                Console.ReadLine();
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Invalid expression was provided.");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press enter...");
                Console.ReadLine();
            }       
        }
    }
}
