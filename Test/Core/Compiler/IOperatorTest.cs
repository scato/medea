using System.Linq;
using Medea.Core.Compiler;
using Medea.Core.FileStorage;
using Medea.Core.JavaScript;
using Medea.Core.Planner;
using Newtonsoft.Json;

namespace Medea.Test.Core.Compiler
{
    abstract public class IOperatorTest
    {
        protected string[] ExecuteOperator(IOperator op)
        {
            var compiler = new QueryPlanCompiler();
            var queryStage = new QueryStage(op);
            var compiledStage = compiler.CompileQueryStage(queryStage);
            compiledStage.FileStorage = new FileStorageFacade();
            compiledStage.JavaScript = new JavaScriptFacade();
            return compiledStage.Execute().Select(r => r.ToString(Formatting.None)).ToArray();
        }

    }
}
