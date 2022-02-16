namespace Medea.Core.Planner.Expression
{
    public class NumericLiteral : IExpression
    {
        public int Id { get; private set; }
        public string Value { get; private set; }

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
