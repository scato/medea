namespace Medea.Core.Planner.Expression
{
    public class SpreadArgument : IExpression
    {
        public int Id { get; }
        public IExpression Expression { get; }

        public SpreadArgument(int id, IExpression expression)
        {
            Id = id;
            Expression = expression;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}
