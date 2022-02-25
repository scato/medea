using System.Linq;
using Medea.Core.DataStorage;
using Medea.Core.DataStorage.CommitLog;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Medea.Test.Core.DataStorage
{
    public class DataStorageFacadeTest
    {
        private DataStorageFacade _dataStorage;
        
        [SetUp]
        public void SetUp()
        {
            _dataStorage = new DataStorageFacade();

            _dataStorage.Append(
                new CommitLogEntry()
                {
                    Action = CommitLogEntry.CREATE_ROW_STORE,
                    Payload = new JObject(new JProperty("name", new JValue("default")))
                }
            );

            _dataStorage.Append(
                new CommitLogEntry()
                {
                    Action = CommitLogEntry.CREATE,
                    Payload = new JObject(new JProperty("year", new JValue("1993")))
                }
            );
        }

        [Test]
        public void ShouldScanRowStore()
        {
            var rows = _dataStorage.Scan("default").Select(r => r.ToString(Formatting.None)).ToArray();

            Assert.AreEqual(new[] { "{\"year\":\"1993\"}" }, rows);
        }
    }
}
