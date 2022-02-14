using Medea.Core.Planner.Expression;

namespace Medea.Core.Planner
{
    public interface IPatternVisitor
    {
        void Accept(StringLiteral stringLiteral);
        void Accept(IdentifierReference identifierReference);
    }
}