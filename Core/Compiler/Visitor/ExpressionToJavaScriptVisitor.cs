using System.Collections.Generic;
using System.Linq;
using Medea.Core.Planner;
using Medea.Core.Planner.Expression;

namespace Medea.Core.Compiler.Visitor
{
    public class ExpressionToJavaScriptVisitor : IExpressionVisitor
    {
        private Stack<string> _stack = new Stack<string>();

        public string Result => _stack.Single();

        public void Accept(StringLiteral stringLiteral)
        {
            _stack.Push(stringLiteral.Value);
        }

        public void Accept(NumericLiteral numericLiteral)
        {
            _stack.Push(numericLiteral.Value);
        }
    }
}
