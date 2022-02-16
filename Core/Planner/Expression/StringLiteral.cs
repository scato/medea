using Medea.Core.Compiler.Visitor;

namespace Medea.Core.Planner.Expression
{
    public class StringLiteral : IExpression, IPattern
    {
        public int Id { get; private set; }

        public StringLiteral(int id, string value)
        {
            this.Id = id;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            throw new System.NotImplementedException();
        }

        public void Accept(IPatternVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}
