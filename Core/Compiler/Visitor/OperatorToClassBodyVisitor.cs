using Medea.Core.Planner;
using Medea.Core.Planner.Operator;
using Microsoft.CodeAnalysis.CSharp;

namespace Medea.Core.Compiler.Visitor
{
    public class OperatorToClassBodyVisitor : IOperatorVisitor
    {
        private string _classBody;

        public string Result => _classBody;

        public OperatorToClassBodyVisitor(IOperator rootOperator)
        {
            var id = rootOperator.Id;
            
            _classBody = @$"
                public JavaScriptFacade JavaScript {{ get; set; }}

                public IEnumerable<JToken> Execute()
                {{
                    return Execute{id}();
                }}
            ";
        }

        public void Visit(ConstantExpressionScan constantExpressionScan)
        {
            var id = constantExpressionScan.Id;

            var visitor = new ExpressionToJavaScriptVisitor();
            constantExpressionScan.Expression.Accept(visitor);
            var expressionNode = SyntaxFactory.Literal(visitor.Result);
            var expressionString = expressionNode.ToFullString();

            _classBody += @$"
                private IEnumerable<JToken> Execute{id}()
                {{
                    var expression = {expressionString};
                    var input = new JObject();

                    return new JToken[]
                    {{
                        JavaScript.Evaluate(expression, input)
                    }};
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
                {visitor.Result}

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
