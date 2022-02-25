using System.Collections.Generic;
using Medea.Core.Executor;
using Medea.Core.Planner;
using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Operator;
using Medea.Core.Service;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Medea.Test.Core.Executor
{
    public class LocalExecutorTest
    {
        private LocalExecutor _executor;

        [SetUp]
        public void Setup()
        {
            var factory = new InMemoryServiceFactory();

            _executor = factory.CreateLocalExecutor();
        }

        [Test]
        public void ShouldExecuteQueries()
        {
            var queryPlan = new QueryPlan(
                new QueryStage(
                    new ConstantExpressionScan(
                        1,
                        new NumericLiteral(1, "1")
                    )
                )
            );

            var results = _executor.Execute(queryPlan);

            Assert.AreEqual(new List<JToken>() { new JValue(1) }, results);
        }
    }
}