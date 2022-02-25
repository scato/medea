using System.Linq;
using Hime.Redist;

namespace Medea.Core.Parser
{
    public static class MedeaParserExtensions
    {
        public static string ToPrettyString(this ASTNode node)
        {
            if (node.SymbolType == SymbolType.Terminal)
            {
                return node.Value;
            }

            var children = string.Join(", ", node.Children.Select(c => c.ToPrettyString()));
            
            return $"{node.Symbol.Name}({children})";
        }
    }
}
