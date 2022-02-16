using System.Collections.Generic;
using Medea.Core.JavaScript;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Compiler
{
    public interface ICompiledQueryStage
    {
        JavaScriptFacade JavaScript { get; set; }

        IEnumerable<JToken> Execute();
    }
}
