using System.Collections.Generic;
using Medea.Core.Executor;
using Medea.Core.Planner;
using Medea.Core.Planner.Operator;
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
            _executor = new LocalExecutor();
        }

        [Test]
        public void ShouldExecuteQueries()
        {
            var queryPlan = new QueryPlan(
                new QueryStage(
                    new ConstantExpressionScan(
                        new List<JToken>() { new JValue("1") }
                    )
                )
            );

            var results = _executor.Execute(queryPlan);

            Assert.AreEqual(new List<JToken>() { new JValue("1") }, results);
        }
    }
}