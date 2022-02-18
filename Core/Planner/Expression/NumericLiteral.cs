namespace Medea.Core.Planner.Expression
{
    public class NumericLiteral : IExpression
    {
        public int Id { get; }
        public string Value { get; }

        public NumericLiteral(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}
