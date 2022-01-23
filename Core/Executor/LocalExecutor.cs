using System;
using System.Collections.Generic;
using Medea.Core.Compiler;
using Medea.Core.Planner;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Executor
{
    public class LocalExecutor : IQueryPlanExecutor
    {
        private QueryPlanCompiler _compiler;

        public LocalExecutor()
        {
            _compiler = new QueryPlanCompiler();
        }

        public IEnumerable<JToken> Execute(QueryPlan queryPlan)
        {
            var result = new List<JToken>();

            foreach (var queryStage in queryPlan.QueryStages)
            {
                var compiledQueryStage = _compiler.CompileQueryStage(queryStage);

                compiledQueryStage.Open();

                var next = compiledQueryStage.Next();
                while (next != null)
                {
                    result.AddRange(next);
                    next = compiledQueryStage.Next();
                }
                
                compiledQueryStage.Close();
            }

            return result;
        }
    }
}
