using System.Collections.Generic;
using Medea.Core.DataStorage.CommitLog;
using Newtonsoft.Json.Linq;

namespace Medea.Core.DataStorage
{
    public interface IRowStore
    {
        IEnumerable<JToken> Scan();
        void HandleLogEntry(CommitLogEntry commitLogEntry);
    }
}
