using Medea.Core.Planner;
using Medea.Core.Planner.Operator;
using Microsoft.CodeAnalysis.CSharp;

namespace Medea.Core.Compiler.Visitor
{
    public class OperatorToClassBodyVisitor : IOperatorVisitor
    {
        private string _classBody = "";

        public string ClassBody => _classBody;

        public OperatorToClassBodyVisitor(IOperator rootOperator)
        {
            var id = rootOperator.Id;
            
            _classBody = @$"
                public IEnumerable<JToken> Execute()
                {{
                    return Execute{id}();
                }}
            ";
        }

        public void Visit(ConstantExpressionScan constantExpressionScan)
        {
            var id = constantExpressionScan.Id;

            _classBody += @$"
                private IEnumerable<JToken> Execute{id}()
                {{
                    return new JToken[] {{ new JValue(1) }};
                }}
            ";
        }

        public void Visit(FileScan fileScan)
        {
            var id = fileScan.Id;
            var dataId = fileScan.DataPattern.Id;

            var fileNameNode = SyntaxFactory.Literal("Fixtures/example.txt");
            var fileNameString = fileNameNode.ToFullString();

            var visitor = new PatternToMatchingMethodVisitor(fileScan.DataPattern);
            fileScan.DataPattern.Accept(visitor);

            _classBody += @$"
                {visitor.MatchingMethod}

                private IEnumerable<JToken> Execute{id}()
                {{
                    var output1 = new List<JToken>() {{
                        new JValue(System.IO.File.ReadAllText({fileNameString}))
                    }};

                    foreach (var record in output1)
                    {{
                        foreach (var output{dataId} in _match{dataId}(record))
                        {{
                            yield return output{dataId};
                        }}
                    }}
                }}
            ";
        }

        public void Visit(Project project)
        {
            throw new System.NotImplementedException();
       }
    }
}
