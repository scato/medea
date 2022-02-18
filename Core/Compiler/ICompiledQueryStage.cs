using System.Collections.Generic;
using Medea.Core.FileStorage;
using Medea.Core.JavaScript;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Compiler
{
    public interface ICompiledQueryStage
    {
        FileStorageFacade FileStorage { get; set; }
        JavaScriptFacade JavaScript { get; set; }

        IEnumerable<JToken> Execute();
    }
}
