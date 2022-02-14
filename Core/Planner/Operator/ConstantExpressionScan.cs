using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Planner.Operator
{
    public class ConstantExpressionScan : IOperator
    {
        public int Id { get; private set; }
        private IExpression _expression;

        public ConstantExpressionScan(int id, IExpression expression)
        {
            Id = id;
            this._expression = expression;
        }

        public void Accept(IOperatorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
