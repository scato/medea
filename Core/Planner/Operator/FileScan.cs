namespace Medea.Core.Planner.Operator
{
    public class FileScan : IOperator
    {
        public int Id { get; private set; }
        public IPattern FileNamePattern { get; private set; }
        public IPattern DataPattern { get; private set; }

        public FileScan(int id, IPattern fileNamePattern, IPattern dataPattern)
        {
            this.Id = id;
            this.FileNamePattern = fileNamePattern;
            this.DataPattern = dataPattern;
        }

        public void Accept(IOperatorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
