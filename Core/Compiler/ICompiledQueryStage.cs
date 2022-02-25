using System.Collections.Generic;
using Medea.Core.DataStorage;
using Medea.Core.FileStorage;
using Medea.Core.JavaScript;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Compiler
{
    public interface ICompiledQueryStage
    {
        DataStorageFacade DataStorage { get; set; }
        FileStorageFacade FileStorage { get; set; }
        JavaScriptFacade JavaScript { get; set; }

        IEnumerable<JToken> Execute();
    }
}
