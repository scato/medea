using Medea.Core.Compiler.Visitor;

namespace Medea.Core.Planner.Expression
{
    public class IdentifierReference : IExpression, IPattern
    {
        public int Id { get; private set; }
        public string Value { get; private set; }

        public IdentifierReference(int id, string value)
        {
            this.Id = id;
            this.Value = value;
        }

        public void Accept(IPatternVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}
