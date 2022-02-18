namespace Medea.Core.Planner.Operator
{
    public class Project : IOperator
    {
        public int Id { get; }
        public IOperator Source { get; }

        public Project(int id, IOperator source)
        {
            Id = id;
            Source = source;
        }

        public void Accept(IOperatorVisitor visitor)
        {
            Source.Accept(visitor);

            visitor.Visit(this);
        }
    }
}
