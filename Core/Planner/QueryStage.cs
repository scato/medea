namespace Medea.Core.Planner
{
    public class QueryStage
    {
        public IOperator RootNode { get; private set; }

        public QueryStage(IOperator rootNode)
        {
            this.RootNode = rootNode;
        }
    }
}
