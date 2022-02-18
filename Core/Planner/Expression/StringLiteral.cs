using Medea.Core.Compiler.Visitor;

namespace Medea.Core.Planner.Expression
{
    public class StringLiteral : IExpression, IPattern, IStringPattern
    {
        public int Id { get; }
        public string Value { get; }

        public StringLiteral(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Accept(this);
        }

        public void Accept(IPatternVisitor visitor)
        {
            visitor.Accept(this);
        }

        public IExpression ToGlobExpression()
        {
            return this;
        }
    }
}
