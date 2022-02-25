using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Operator;
using NUnit.Framework;

namespace Medea.Test.Core.Compiler.Operator
{
    public class ConstantExpressionScanTest : IOperatorTest
    {
        [Test]
        public void ShouldEvaluateExpression()
        {
            var result = ExecuteOperator(
                new ConstantExpressionScan(
                    1,
                    new NumericLiteral(2, "1")
                )
            );

            Assert.AreEqual(new[] { "1" }, result);
        }
    }
}
