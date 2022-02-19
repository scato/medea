using Medea.Core.Planner.Expression;

namespace Medea.Core.Planner
{
    public interface IPatternVisitor
    {
        void Visit(StringLiteral stringLiteral);
        void Visit(IdentifierReference identifierReference);
    }
}