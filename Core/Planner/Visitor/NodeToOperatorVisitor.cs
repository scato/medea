using System.Collections.Generic;
using System.Linq;
using Hime.Redist;
using Medea.Core.Parser;
using Medea.Core.Planner.Operator;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Planner.Visitor
{
    public class NodeToOperatorVisitor : MedeaParser.Visitor
    {
        private List<IOperator> _rootOperators;

        public QueryPlan QueryPlan
        {
            get
            {
                return new QueryPlan(
                    _rootOperators.Select(o => new QueryStage(o)).ToArray()
                );
            }
        }

        public NodeToOperatorVisitor()
        {
            _rootOperators = new List<IOperator>();
        }

        public override void OnVariableReturn(ASTNode node)
        {
            var records = new JToken[] {};
            _rootOperators.Add(new ConstantExpressionScan(records));
        }
    }
}