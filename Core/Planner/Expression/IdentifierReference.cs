using Medea.Core.Compiler.Visitor;

namespace Medea.Core.Planner.Expression
{
    public class IdentifierReference : IExpression, IPattern, IStringPattern
    {
        public int Id { get; }
        public string Value { get; }

        public IdentifierReference(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Accept(IPatternVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IExpression ToGlobExpression()
        {
            throw new System.NotImplementedException();
        }
    }
}
