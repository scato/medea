using System.Collections.Generic;
using System.Linq;
using Hime.Redist;
using Medea.Core.Parser;
using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Operator;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Planner.Visitor
{
    public class NodeToOperatorVisitor : MedeaParser.Visitor
    {
        private int _nextId = 1;
        private Stack<IQueryPlanNode> _stack = new Stack<IQueryPlanNode>();

        public QueryPlan QueryPlan
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

            _stack.Push(new ConstantExpressionScan(id, expression));
        }

        public override void OnVariableLoad(ASTNode node)
        {
            var id = _nextId++;
            var dataPattern = (IPattern) _stack.Pop();
            var fileNamePattern = (IPattern) _stack.Pop();

            _stack.Push(new FileScan(id, fileNamePattern, dataPattern));
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
    }
}
