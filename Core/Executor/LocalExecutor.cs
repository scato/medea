using System.Collections.Generic;
using Medea.Core.Compiler;
using Medea.Core.DataStorage;
using Medea.Core.FileStorage;
using Medea.Core.JavaScript;
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
            foreach (var queryStage in queryPlan.QueryStages)
            {
                var compiledQueryStage = _compiler.CompileQueryStage(queryStage);
                compiledQueryStage.DataStorage = new DataStorageFacade();
                compiledQueryStage.FileStorage = new FileStorageFacade();
                compiledQueryStage.JavaScript = new JavaScriptFacade();

                foreach (var record in compiledQueryStage.Execute())
                {
                    yield return record;
                }
            }
        }
    }
}
