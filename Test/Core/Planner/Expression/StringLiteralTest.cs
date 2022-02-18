using Medea.Core.Planner.Expression;
using NUnit.Framework;

namespace Medea.Test.Core.Planner.Expression
{
    public class StringLiteralTest
    {
        [Test]
        public void ShouldTurnIntoGlobExpression()
        {
            var pattern = new StringLiteral(1, "\"Fixtures/example.txt\"");

            var expression = pattern.ToGlobExpression();

            Assert.IsInstanceOf<StringLiteral>(expression);
            Assert.AreEqual("\"Fixtures/example.txt\"", ((StringLiteral) expression).Value);
        }
    }
}
