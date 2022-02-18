namespace Medea.Core.Planner
{
    public interface IStringPattern : IPattern
    {
        IExpression ToGlobExpression();
    }
}
