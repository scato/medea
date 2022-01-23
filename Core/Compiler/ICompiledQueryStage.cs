using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Compiler
{
    public interface ICompiledQueryStage
    {
        void Open();
        IEnumerable<JToken> Next();
        void Close();
    }
}
