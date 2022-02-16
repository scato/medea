namespace Medea.Core.Planner
{
    public interface IExpression : IQueryPlanNode
    {
        void Accept(IExpressionVisitor visitor);
    }
}
