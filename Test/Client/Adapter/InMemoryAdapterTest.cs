using NUnit.Framework;
using Medea.Client.Adapter;
using Medea.Client;
using System.Collections.Generic;
using System.Text.Json;

namespace Medea.Test.Client.Adapter
{
    public class InMemoryAdapterTest
    {
        public class QueryServiceFake
        {
            private IEnumerable<JsonDocument> _results;

            public QueryServiceFake(IEnumerable<JsonDocument> results)
            {
                _results = results;
            }

            public IEnumerable<JsonDocument> Execute(string queryString)
            {
                return _results;
            }
        }

        private IEnumerable<JsonDocument> _results;
        private QueryServiceFake _queryServiceFake;
        private InMemoryAdapter _adapter;

        [SetUp]
        public void SetUp()
        {
            _results = new List<JsonDocument>() { JsonDocument.Parse("1") };
            _queryServiceFake = new QueryServiceFake(_results);
            
            _adapter = new InMemoryAdapter(_queryServiceFake);
        }

        [Test]
        public void ShouldAddResultsToQuery()
        {
            var query = new Query("RETURN 1;");

            _adapter.Execute(query);

            Assert.AreEqual(_results, query.Results);
        }
    }
}
