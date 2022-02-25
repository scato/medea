using System;
using System.Collections.Generic;
using Medea.Core.DataStorage.CommitLog;
using Medea.Core.DataStorage.RowStore;
using Newtonsoft.Json.Linq;

namespace Medea.Core.DataStorage
{
    public class DataStorageFacade
    {
        private List<CommitLogEntry> _commitLog;
        private Dictionary<string, IRowStore> _rowStores;

        public DataStorageFacade()
        {
            _commitLog = new List<CommitLogEntry>();
            _rowStores = new Dictionary<string, IRowStore>();
        }

        private void HandleLogEntry(CommitLogEntry commitLogEntry)
        {
            switch (commitLogEntry.Action)
            {
                case CommitLogEntry.CREATE_ROW_STORE:
                    var rowStoreName = (string) ((JValue) commitLogEntry.Payload["name"]).Value;
                    _rowStores[rowStoreName] = new InMemoryRowStore();
                    break;
                case CommitLogEntry.CREATE:
                    foreach (var _rowStore in _rowStores)
                    {
                        _rowStore.Value.HandleLogEntry(commitLogEntry);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void Append(CommitLogEntry commitLogEntry)
        {
            _commitLog.Add(commitLogEntry);

            HandleLogEntry(commitLogEntry);
        }

        public IEnumerable<JToken> Scan(string rowStoreName)
        {
            if (!_rowStores.ContainsKey(rowStoreName))
            {
                throw new ArgumentException($"No row store exists with the name '{rowStoreName}'");
            }

            var rowStore = _rowStores[rowStoreName];

            return rowStore.Scan();
        }
    }
}
