namespace Medea.Core.Planner.Expression
{
    public class Arguments : IExpression
    {
        public int Id { get; }
        public IExpression[] Expressions { get; }

        public Arguments(int id, params IExpression[] expressions)
        {
            Id = id;
            Expressions = expressions;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            foreach (var expression in Expressions)
            {
                expression.Accept(visitor);
            }

            visitor.Visit(this);
        }
    }
}
