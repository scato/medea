using Medea.Core.Planner.Expression;
using Medea.Core.Planner.Operator;
using NUnit.Framework;

namespace Medea.Test.Core.Compiler.Operator
{
    public class FileScanTest : IOperatorTest
    {
        [Test]
        public void ShouldReadFile()
        {
            var result = ExecuteOperator(
                new FileScan(
                    1,
                    "RAW",
                    new StringLiteral(2, "\"Fixtures/Examples/example.txt\""),
                    new IdentifierReference(3, "contents")
                )
            );

            // remove \r on Windows
            result[0] = result[0].Replace("\\r", "");

            Assert.AreEqual(new[] { "{\"contents\":\"foo\\nbar\\n\"}" }, result);
        }
    }
}
