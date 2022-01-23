namespace Medea.Core.Planner
{
    public class QueryPlan
    {
        public QueryStage[] QueryStages;

        public QueryPlan(params QueryStage[] queryStages)
        {
            this.QueryStages = queryStages;
        }
    }
}
