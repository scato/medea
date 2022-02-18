using System;
using System.Collections.Generic;
using System.Linq;
using Medea.Core.Planner;
using Medea.Core.Planner.Expression;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Compiler.Visitor
{
    public class PatternToMatchMethodVisitor : IPatternVisitor
    {
        private int _rootId;
        private List<string> _prefixes = new List<string>();
        private List<string> _properties = new List<string>();
        private List<string> _postfixes = new List<string>();

        public string Result => $@"
            private IEnumerable<JToken> Match{_rootId}(JToken input{_rootId})
            {{
                {string.Join("\n", ((IEnumerable<string>) _prefixes).Reverse())}
                yield return new JObject({string.Join(", ", _properties)});
                {string.Join("\n", _postfixes)}
            }}
        ";

        public PatternToMatchMethodVisitor(IPattern rootPattern)
        {
            _rootId = rootPattern.Id;
        }

        public void Accept(StringLiteral stringLiteral)
        {
            var id = stringLiteral.Id;
            var valueJson = stringLiteral.Value;

            var valueToken = (JValue) JToken.Parse(valueJson);
            var valueNode = SyntaxFactory.Literal((string) valueToken.Value);
            var valueString = valueNode.ToFullString();

            _prefixes.Add(
                $"if (input{id} is JValue value{id} && value{id}.Value is string string{id} && string{id} == {valueString}) {{"
            );
            _postfixes.Add(
                $"}}"
            );
        }

        public void Accept(IdentifierReference identifierReference)
        {
            var id = identifierReference.Id;
            var identifier = identifierReference.Value;

            _properties.Add(
                $"new JProperty(\"{identifier}\", input{id})"
            );
        }
    }
}
