namespace Medea.Core.Planner.Expression
{
    public class CallExpression : IExpression
    {
        public int Id { get; }
        public IExpression Subject { get; }
        public string Identifier { get; }
        public Arguments Arguments { get; }

        public CallExpression(int id, IExpression subject, string identifier, Arguments arguments)
        {
            Id = id;
            Subject = subject;
            Identifier = identifier;
            Arguments = arguments;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            Subject.Accept(visitor);
            Arguments.Accept(visitor);

            visitor.Visit(this);
        }
    }
}
