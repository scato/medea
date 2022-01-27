using System;
using System.Collections.Generic;
using Medea.Core.Parser;
using Medea.Core.Planner.Operator;
using Medea.Core.Planner.Visitor;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Planner
{
    public class QueryPlanner
    {
        public QueryPlan CreatePlan(Hime.Redist.ParseResult result)
        {
            var visitor = new NodeToOperatorVisitor();

            MedeaParser.Visit(result, visitor);

            return visitor.QueryPlan;
        }
    }
}
