using Newtonsoft.Json.Linq;

namespace Medea.Core.DataStorage.CommitLog
{
    public class CommitLogEntry
    {
        public const string CREATE_ROW_STORE = "CREATE ROW STORE";
        public const string CREATE = "CREATE";

        public string Action { get; set; }
        public JToken Payload { get; set; }
    }
}
