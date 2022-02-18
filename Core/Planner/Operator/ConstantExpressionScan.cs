using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Planner.Operator
{
    public class ConstantExpressionScan : IOperator
    {
        public int Id { get; }
        public IExpression Expression { get; }

        public ConstantExpressionScan(int id, IExpression expression)
        {
            Id = id;
            Expression = expression;
        }

        public void Accept(IOperatorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
