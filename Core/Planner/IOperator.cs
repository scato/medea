namespace Medea.Core.Planner
{
    public interface IOperator
    {
        void Accept(IOperatorVisitor visitor);
    }
}