namespace Medea.Core.Planner.Expression
{
    public class NumericLiteral : IExpression
    {
        public int Id { get; private set; }

        public NumericLiteral(int id, string value)
        {
            this.Id = id;
        }
    }
}
