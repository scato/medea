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

        public void Visit(CallExpression callExpression)
        {
            var arguments = _stack.Pop();
            var identifier = callExpression.Identifier;
            var subject = _stack.Pop();

            _stack.Push($"{subject}.{identifier}({arguments})");
        }

        public void Visit(Arguments arguments)
        {
            var numExpressions = arguments.Expressions.Length;
            var expressions = new string[numExpressions];

            for (var i = numExpressions - 1; i >= 0; i--)
            {
                expressions[i] = _stack.Pop();
            }

            _stack.Push(string.Join(", ", expressions));
        }

        public void Visit(SpreadArgument spreadArgument)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(IdentifierReference identifierReference)
        {
            _stack.Push(identifierReference.Value);
        }

        public void Visit(StringLiteral stringLiteral)
        {
            _stack.Push(stringLiteral.Value);
        }

        public void Visit(NumericLiteral numericLiteral)
        {
            _stack.Push(numericLiteral.Value);
        }

        public void Visit(RegularExpressionLiteral regularExpressionLiteral)
        {
            _stack.Push(regularExpressionLiteral.Value);
        }
    }
}
