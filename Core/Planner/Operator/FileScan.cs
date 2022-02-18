namespace Medea.Core.Planner.Operator
{
    public class FileScan : IOperator
    {
        public int Id { get; }
        public string Format { get; }
        public IStringPattern PathPattern { get; }
        public IPattern DataPattern { get; }

        public FileScan(int id, string format, IStringPattern pathPattern, IPattern dataPattern)
        {
            Id = id;
            Format = format;
            PathPattern = pathPattern;
            DataPattern = dataPattern;
        }

        public void Accept(IOperatorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
