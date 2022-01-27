using System.Collections.Generic;
using Medea.Core.Service;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Medea.Test.Core.Service
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

            Assert.AreEqual(new List<JToken>() { new JValue(1) }, results);
        }
    }
}