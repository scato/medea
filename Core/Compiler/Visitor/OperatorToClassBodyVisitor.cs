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
                public FileStorageFacade FileStorage {{ get; set; }}

                public IEnumerable<JToken> Execute()
                {{
                    return Execute{id}();
                }}
            ";
        }

        private string StringToCSharp(string value)
        {
            return SyntaxFactory.Literal(value).ToFullString();
        }

        private string ExpressionToJavaScript(IExpression expression)
        {
            var visitor = new ExpressionToJavaScriptVisitor();
            expression.Accept(visitor);
            return visitor.Result;
        }

        private string PatternToMatchMethod(IPattern pattern)
        {
            var visitor = new PatternToMatchMethodVisitor(pattern);
            pattern.Accept(visitor);
            return visitor.Result;
        }

        public void Visit(ConstantExpressionScan constantExpressionScan)
        {
            var id = constantExpressionScan.Id;

            var expressionLiteral = StringToCSharp(
                ExpressionToJavaScript(constantExpressionScan.Expression)
            );

            _classBody += @$"
                private IEnumerable<JToken> Execute{id}()
                {{
                    return new JToken[]
                    {{
                        JavaScript.Evaluate({expressionLiteral}, new JObject())
                    }};
                }}
            ";
        }

        public void Visit(FileScan fileScan)
        {
            var id = fileScan.Id;

            var format = fileScan.Format;

            var pathId = fileScan.PathPattern.Id;
            var globExpression = fileScan.PathPattern.ToGlobExpression();
            var globLiteral = StringToCSharp(
                ExpressionToJavaScript(globExpression)
            );
            var pathMatchMethod = PatternToMatchMethod(fileScan.PathPattern);

            var dataId = fileScan.DataPattern.Id;
            var dataMatchMethod = PatternToMatchMethod(fileScan.DataPattern);

            _classBody += @$"
                {pathMatchMethod}
                {dataMatchMethod}

                private IEnumerable<JToken> Execute{id}()
                {{
                    var glob = (JValue) JavaScript.Evaluate({globLiteral}, new JObject());

                    foreach (var path in FileStorage.List((string) glob.Value))
                    {{
                        foreach (var output{pathId} in Match{pathId}(path))
                        {{
                            foreach (var record in FileStorage.Read(path, FileStorageFormat.{format}))
                            {{
                                foreach (var output{dataId} in Match{dataId}(record))
                                {{
                                    yield return output{dataId};
                                }}
                            }}
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
