using System.Collections.Generic;
using System.Linq;
using Hime.Redist;
using Medea.Core.Parser;
using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Operator;

namespace Medea.Core.Planner.Visitor
{
    public class NodeToOperatorVisitor : MedeaParser.Visitor
    {
        private int _nextId = 1;
        private Stack<IQueryPlanNode> _stack = new Stack<IQueryPlanNode>();

        public QueryPlan Result
        {
            get
            {
                return new QueryPlan(
                    _stack.Select(o => new QueryStage((IOperator) o)).ToArray()
                );
            }
        }

        public override void OnVariableReturn(ASTNode node)
        {
            var id = _nextId++;
            var expression = (IExpression) _stack.Pop();

            if (_stack.Count > 0)
            {
                var source = (IOperator) _stack.Pop();

                _stack.Push(new Projection(id, source, expression));
            }
            else
            {
                _stack.Push(new ConstantExpressionScan(id, expression));
            }
        }

        public override void OnVariableLoad(ASTNode node)
        {
            var id = _nextId++;
            var format = node.Children[0].Value.ToUpper();
            var dataPattern = (IPattern) _stack.Pop();
            var pathPattern = (IStringPattern) _stack.Pop();

            _stack.Push(new FileScan(id, format, pathPattern, dataPattern));
        }

        public override void OnVariableCallExpression(ASTNode node)
        {
            var numCalls = (node.Children.Count - 1) / 2;
            var argumentLists = new Arguments[numCalls];
            var identifiers = new string[numCalls];

            for (var i = numCalls - 1; i >= 0; i--)
            {
                argumentLists[i] = (Arguments) _stack.Pop();
                identifiers[i] = node.Children[1 + 2 * i].Value;
            }

            var subject = (IExpression) _stack.Pop();

            for (var i = 0; i < numCalls; i++)
            {
                var id = _nextId++;
                subject = new CallExpression(id, subject, identifiers[i], argumentLists[i]);
            }

            _stack.Push(subject);
        }

        public override void OnVariableArguments(ASTNode node)
        {
            var id = _nextId++;
            var numArguments = node.Children.Count;
            var expressions = new IExpression[numArguments];

            for (var i = numArguments - 1; i >= 0; i--)
            {
                expressions[i] = (IExpression) _stack.Pop();
            }

            _stack.Push(new Arguments(id, expressions));
        }

        public override void OnVariableSpreadArgument(ASTNode node)
        {
            var id = _nextId++;
            var expression = (IExpression) _stack.Pop();

            _stack.Push(new SpreadArgument(id, expression));
        }

        public override void OnVariableIdentifierReference(ASTNode node)
        {
            var id = _nextId++;
            var value = node.Children[0].Value;

            _stack.Push(new IdentifierReference(id, value));
        }

        public override void OnVariableStringLiteral(ASTNode node)
        {
            var id = _nextId++;
            var value = node.Children[0].Value;

            _stack.Push(new StringLiteral(id, value));
        }

        public override void OnVariableNumericLiteral(ASTNode node)
        {
            var id = _nextId++;
            var value = node.Children[0].Value;

            _stack.Push(new NumericLiteral(id, value));
        }

        public override void OnVariableRegularExpressionLiteral(ASTNode node)
        {
            var id = _nextId++;
            var value = node.Children[0].Value;

            _stack.Push(new RegularExpressionLiteral(id, value));
        }
    }
}
