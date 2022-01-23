using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Planner.Operator
{
    public class ConstantExpressionScan : IOperator
    {
        private IEnumerable<JToken> _records;

        public ConstantExpressionScan(IEnumerable<JToken> records)
        {
            this._records = records;
        }

        public void Accept(IOperatorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
