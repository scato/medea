using Medea.Core.Planner.Expression;

namespace Medea.Core.Planner
{
    public interface IExpressionVisitor
    {
        void Accept(NumericLiteral numericLiteral);
    }
}
