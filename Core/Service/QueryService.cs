using System.Collections.Generic;
using System.Text.Json;

namespace Medea.Core.Service
{
    public class QueryService
    {
        public QueryService()
        {
            // _parser = new Parser();
        }

        public IEnumerable<JsonDocument> Execute(string queryString)
        {
            return new List<JsonDocument>();
        }
    }
}
