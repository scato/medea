using Hime.Redist;
using Medea.Core.Parser;
using NUnit.Framework;

namespace Medea.Test.Core.Parser
{
    public class MedeaParserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldParseQueries()
        {
            var lexer = new MedeaLexer("RETURN 1;");
            var parser = new MedeaParser(lexer);
            var result = parser.Parse();

            var script = result.Root;
            Assert.AreEqual("Script", script.Symbol.Name);

            var query = script.Children[0];
            Assert.AreEqual("Query", query.Symbol.Name);

            var return_ = query.Children[0];
            Assert.AreEqual("Return", return_.Symbol.Name);

            var numericLiteral = return_.Children[0];
            Assert.AreEqual("NumericLiteral", numericLiteral.Symbol.Name);
        }

        [Test]
        public void ShouldMatchLowerCaseKeywords()
        {
            var lexer = new MedeaLexer("return 1;");
            var parser = new MedeaParser(lexer);
            var result = parser.Parse();

            Assert.IsInstanceOf<ParseResult>(result);
        }
    }
}