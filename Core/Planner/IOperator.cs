namespace Medea.Core.Planner
{
    public interface IOperator : IQueryPlanNode
    {
        void Accept(IOperatorVisitor visitor);
    }
}