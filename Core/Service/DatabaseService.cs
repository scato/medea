using System;
using Medea.Core.DataStorage;
using Medea.Core.DataStorage.CommitLog;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Service
{
    public class DatabaseService
    {
        private DataStorageFacade _dataStorageFacade;

        public DatabaseService(DataStorageFacade dataStorageFacade)
        {
            _dataStorageFacade = dataStorageFacade;
        }

        public void Initialize()
        {
            _dataStorageFacade.Append(new CommitLogEntry() {
                Action = CommitLogEntry.CREATE_ROW_STORE,
                Payload = new JObject(new JProperty("name", new JValue("default")))
            });
        }
    }
}
