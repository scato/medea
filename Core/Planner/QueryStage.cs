namespace Medea.Core.Planner
{
    public class QueryStage
    {
        public IOperator RootNode { get; }

        public QueryStage(IOperator rootNode)
        {
            RootNode = rootNode;
        }
    }
}
