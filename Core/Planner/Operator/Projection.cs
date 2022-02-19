namespace Medea.Core.Planner.Operator
{
    public class Projection : IOperator
    {
        public int Id { get; }
        public IOperator Source { get; }
        public IExpression Expression { get; }

        public Projection(int id, IOperator source, IExpression expression)
        {
            Id = id;
            Source = source;
            Expression = expression;
        }

        public void Accept(IOperatorVisitor visitor)
        {
            Source.Accept(visitor);

            visitor.Visit(this);
        }
    }
}
