namespace Medea.Core.Planner
{
    public class QueryStage
    {
        public IOperator RootNode;

        public QueryStage(IOperator _rootNode)
        {
            this.RootNode = _rootNode;
        }
    }
}
