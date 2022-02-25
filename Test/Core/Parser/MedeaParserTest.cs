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

        [TestCaseSource("ParseTreeExamples")]
        public void ShouldParseQuery(string query, string tree)
        {
            var lexer = new MedeaLexer(query);
            var parser = new MedeaParser(lexer);
            var result = parser.Parse();

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(tree, result.Root.ToPrettyString());
        }

        private static string[][] ParseTreeExamples()
        {
            return new[]
            {
                new[] {
                    @"RETURN 1;",
                    @"Script(Query(Return(NumericLiteral(1))))"
                },
                new[] {
                    @"LOAD RAW FROM ""Fixtures/example.txt"" AS contents;",
                    @"Script(Query(Load(RAW, StringLiteral(""Fixtures/example.txt""), IdentifierReference(contents))))"
                },
                new[] {
                    @"RETURN contents.replace(/\r/g, """");",
                    @"Script(Query(Return(CallExpression(IdentifierReference(contents), replace, Arguments(RegularExpressionLiteral(/\r/g), StringLiteral(""""))))))"
                },
                new[] {
                    @"MATCH game;",
                    @"Script(Query(Match(IdentifierReference(game))))"
                },
            };
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