using System.Collections.Generic;
using System.Linq;
using Medea.Core.Compiler;
using Medea.Core.Planner;
using Medea.Core.Planner.Operator;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Medea.Test.Core.Compiler
{
    public class QueryPlanCompilerTest
    {
        private QueryPlanCompiler _compiler;

        [SetUp]
        public void Setup()
        {
            _compiler = new QueryPlanCompiler();
        }

        [Test]
        public void ShouldCompileQueryStages()
        {
            var queryStage = new QueryStage(
                new ConstantExpressionScan(
                    new List<JToken>() { new JValue("1") }
                )
            );

            var compiledStage = _compiler.CompileQueryStage(queryStage);

            compiledStage.Open();

            var chunk = compiledStage.Next();
            Assert.NotNull(chunk);
            Assert.AreEqual(1, chunk.Count());
            Assert.AreEqual("1", chunk.ElementAt(0).ToString());

            chunk = compiledStage.Next();
            Assert.Null(chunk);

            compiledStage.Close();
        }
    }
}
