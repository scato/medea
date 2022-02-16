using System.Collections.Generic;
using Medea.Core.Planner;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Executor
{
    public interface IQueryPlanExecutor
    {
        IEnumerable<JToken> Execute(QueryPlan queryPlan);
    }
}
