using ExpressionEvaluator.Symbols;
using System;
using System.Collections.Generic;

namespace ExpressionEvaluator
{
    internal class ParsingContext
    {
        public string Input { get; set; }

        public LastToken LastRead {get; private set;}

        public List<AbstractSymbol> Output { get; set; }

        public Stack<NonTerminalSymbol> Operators { get; set; }

        public ParsingContext(string input)
        {
            this.Input = input;
            Output = new List<AbstractSymbol>();
            Operators = new Stack<NonTerminalSymbol>();
            LastRead = LastToken.None;
        }

        internal char GetFirstChar() => Input[0];

        internal int ReadNumber()
        {
            int i = 0;
            while (i < Input.Length && Char.IsDigit(Input[i]))
                i++;
            int ret = int.Parse(Input.Substring(0, i));
            Input = Input.Substring(i);
            LastRead = LastToken.Value;
            return ret;
        }

        internal char ReadOperator()
        {
            char op = Input[0];
            Input = Input.Substring(1);
            LastRead = LastToken.Operator;
            return op;
        }
    }
}