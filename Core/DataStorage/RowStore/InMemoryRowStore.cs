using System.Collections.Generic;
using Medea.Core.DataStorage.CommitLog;
using Newtonsoft.Json.Linq;

namespace Medea.Core.DataStorage.RowStore
{
    public class InMemoryRowStore : IRowStore
    {
        private List<JToken> _rows;

        public InMemoryRowStore()
        {
            _rows = new List<JToken>();
        }

        public void HandleLogEntry(CommitLogEntry commitLogEntry)
        {
            switch(commitLogEntry.Action)
            {
                case CommitLogEntry.CREATE:
                    _rows.Add(commitLogEntry.Payload);
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }

        public IEnumerable<JToken> Scan()
        {
            return _rows;
        }
    }
}
