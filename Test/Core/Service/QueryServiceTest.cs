using System.Linq;
using System.Text.Json;
using Medea.Core.Service;
using NUnit.Framework;

namespace Tests
{
    public class QueryServiceTest
    {
        private QueryService _queryService;

        [SetUp]
        public void Setup()
        {
            _queryService = new QueryService();
        }

        [Test]
        public void ShouldExecuteQueries()
        {
            var results = _queryService.Execute("RETURN 1;");

            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(JsonDocument.Parse("1"), results.ElementAt(0));
        }
    }
}