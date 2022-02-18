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
            throw new System.NotImplementedException();
        }

        public void Accept(IPatternVisitor visitor)
        {
            visitor.Accept(this);
        }

        public IExpression ToGlobExpression()
        {
            throw new System.NotImplementedException();
        }
    }
}
