using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Operator;
using NUnit.Framework;

namespace Medea.Test.Core.Compiler.Operator
{
    public class RowStoreScanTest : IOperatorTest
    {
        [Test]
        public void ShouldScanRowStore()
        {
            var result = ExecuteOperator(
                new RowStoreScan(
                    1,
                    new IdentifierReference(2, "game")
                )
            );

            Assert.AreEqual(new[] { "{\"game\":{\"year\":\"1993\"}}" }, result);
        }
    }
}
