using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Visitor;

namespace Medea.Core.Planner
{
    public interface IExpressionVisitor
    {
        void Visit(CallExpression callExpression);
        void Visit(Arguments arguments);
        void Visit(SpreadArgument spreadArgument);
        void Visit(NumericLiteral numericLiteral);
        void Visit(StringLiteral stringLiteral);
        void Visit(IdentifierReference identifierReference);
        void Visit(RegularExpressionLiteral regularExpressionLiteral);
    }
}
