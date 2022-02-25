using Medea.Core.Planner.Operator;

namespace Medea.Core.Planner
{
    public interface IOperatorVisitor
    {
        void Visit(ConstantExpressionScan constantExpressionScan);
        void Visit(FileScan fileScan);
        void Visit(Projection projection);
        void Visit(RowStoreScan rowStoreScan);
    }
}
