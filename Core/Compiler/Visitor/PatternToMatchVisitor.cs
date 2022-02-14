using System;
using System.Collections.Generic;
using Medea.Core.Planner;
using Medea.Core.Planner.Expression;

namespace Medea.Core.Compiler.Visitor
{
    public class PatternToMatchingMethodVisitor : IPatternVisitor
    {
        private int _rootId;
        private List<string> _properties = new List<string>();

        public string MatchingMethod => $@"
            private IEnumerable<JToken> _match{_rootId}(JToken input{_rootId})
            {{
                yield return new JObject({string.Join(", ", _properties)});
            }}
        ";

        public PatternToMatchingMethodVisitor(IPattern rootPattern)
        {
            _rootId = rootPattern.Id;
        }

        public void Accept(StringLiteral stringLiteral)
        {
            throw new NotImplementedException();
        }

        public void Accept(IdentifierReference identifierReference)
        {
            var id = identifierReference.Id;
            var identifier = identifierReference.Value;

            _properties.Add($"new JProperty(\"{identifier}\", input{id})");
        }
    }
}
