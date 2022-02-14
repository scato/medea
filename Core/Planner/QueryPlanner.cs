using Hime.Redist;
using Medea.Core.Parser;
using Medea.Core.Planner.Visitor;

namespace Medea.Core.Planner
{
    public class QueryPlanner
    {
        public QueryPlan CreatePlan(ParseResult result)
        {
            var visitor = new NodeToOperatorVisitor();

            MedeaParser.Visit(result, visitor);

            return visitor.QueryPlan;
        }
    }
}
