using Medea.Core.Planner.Operator;

namespace Medea.Core.Planner
{
    public interface IOperatorVisitor
    {
        void Visit(ConstantExpressionScan queryOperator);
    }
}
