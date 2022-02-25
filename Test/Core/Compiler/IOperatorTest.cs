using System.Linq;
using Medea.Core.Compiler;
using Medea.Core.DataStorage;
using Medea.Core.DataStorage.CommitLog;
using Medea.Core.FileStorage;
using Medea.Core.JavaScript;
using Medea.Core.Planner;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Medea.Test.Core.Compiler
{
    abstract public class IOperatorTest
    {
        private DataStorageFacade _dataStorage;

        [SetUp]
        public void SetUp()
        {
            _dataStorage = new DataStorageFacade();

            _dataStorage.Append(
                new CommitLogEntry()
                {
                    Action = CommitLogEntry.CREATE_ROW_STORE,
                    Payload = new JObject(new JProperty("name", new JValue("default")))
                }
            );

            _dataStorage.Append(
                new CommitLogEntry()
                {
                    Action = CommitLogEntry.CREATE,
                    Payload = new JObject(new JProperty("year", new JValue("1993")))
                }
            );
        }

        protected string[] ExecuteOperator(IOperator op)
        {
            var compiler = new QueryPlanCompiler();
            var queryStage = new QueryStage(op);
            var compiledStage = compiler.CompileQueryStage(queryStage);
            compiledStage.DataStorage = _dataStorage;
            compiledStage.FileStorage = new FileStorageFacade();
            compiledStage.JavaScript = new JavaScriptFacade();
            return compiledStage.Execute().Select(r => r.ToString(Formatting.None)).ToArray();
        }

    }
}
