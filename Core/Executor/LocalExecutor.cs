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
        private DataStorageFacade _dataStorage;
        private FileStorageFacade _fileStorage;
        private JavaScriptFacade _javaScript;

        public LocalExecutor(
            QueryPlanCompiler compiler,
            DataStorageFacade dataStorage,
            FileStorageFacade fileStorage,
            JavaScriptFacade javaScript
        )
        {
            _compiler = compiler;
            _dataStorage = dataStorage;
            _fileStorage = fileStorage;
            _javaScript = javaScript;
        }

        public IEnumerable<JToken> Execute(QueryPlan queryPlan)
        {
            foreach (var queryStage in queryPlan.QueryStages)
            {
                var compiledQueryStage = _compiler.CompileQueryStage(queryStage);
                compiledQueryStage.DataStorage = _dataStorage;
                compiledQueryStage.FileStorage = _fileStorage;
                compiledQueryStage.JavaScript = _javaScript;

                foreach (var record in compiledQueryStage.Execute())
                {
                    yield return record;
                }
            }
        }
    }
}
