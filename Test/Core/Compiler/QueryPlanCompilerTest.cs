using System.Linq;
using Medea.Core.Compiler;
using Medea.Core.Planner;
using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Operator;
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
                    1,
                    new NumericLiteral(1, "1")
                )
            );

            var compiledStage = _compiler.CompileQueryStage(queryStage);
            var result = compiledStage.Execute().ToList();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("1", result.ElementAt(0).ToString());
        }
    }
}
