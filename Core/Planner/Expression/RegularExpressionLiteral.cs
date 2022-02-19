namespace Medea.Core.Planner.Expression
{
    public class RegularExpressionLiteral : IExpression
    {
        public int Id { get; }
        public string Value { get; }

        public RegularExpressionLiteral(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
