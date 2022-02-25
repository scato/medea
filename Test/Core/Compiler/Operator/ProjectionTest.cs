using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Operator;
using NUnit.Framework;

namespace Medea.Test.Core.Compiler.Operator
{
    public class ProjectionTest : IOperatorTest
    {
        [Test]
        public void ShouldEvaluateExpression()
        {
            var result = ExecuteOperator(
                new Projection(
                    1,
                    new FileScan(
                        2,
                        "RAW",
                        new StringLiteral(3, "\"Fixtures/Examples/example.txt\""),
                        new IdentifierReference(4, "contents")
                    ),
                    new CallExpression(
                        5,
                        new IdentifierReference(6, "contents"),
                        "replace",
                        new Arguments(
                            7,
                            new RegularExpressionLiteral(8, "/\\r?\\nbar\\r?\\n/"),
                            new StringLiteral(9, "\"\"")
                        )
                    )
                )
            );

            Assert.AreEqual(new[] { "\"foo\"" }, result);
        }
    }
}
