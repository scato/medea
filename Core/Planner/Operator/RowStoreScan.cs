namespace Medea.Core.Planner.Operator
{
    public class RowStoreScan : IOperator
    {
        public int Id { get; }
        public IPattern Pattern { get; }

        public RowStoreScan(int id, IPattern pattern)
        {
            Id = id;
            Pattern = pattern;
        }

        public void Accept(IOperatorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
