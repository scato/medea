using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Compiler
{
    public interface ICompiledQueryStage
    {
        IEnumerable<JToken> Execute();
    }
}
