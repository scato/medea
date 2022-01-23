using System.Linq;
using Medea.Core.Parser;
using Medea.Core.Planner;
using Medea.Core.Planner.Operator;
using NUnit.Framework;

namespace Medea.Test.Core.Planner
{
    public class QueryPlannerTest
    {
        private QueryPlanner _planner;

        [SetUp]
        public void Setup()
        {
            _planner = new QueryPlanner();
        }

        [Test]
        public void ShouldCreateQueryPlans()
        {
            var lexer = new MedeaLexer("RETURN 1;");
            var parser = new MedeaParser(lexer);
            var result = parser.Parse();

            var queryPlan = _planner.CreatePlan(result);

            Assert.AreEqual(1, queryPlan.QueryStages.Count());
            Assert.IsInstanceOf<ConstantExpressionScan>(queryPlan.QueryStages.ElementAt(0).RootNode);
        }
    }
}