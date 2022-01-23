using NUnit.Framework;
using Medea.Client;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Medea.Test.Client
{
    public class QueryTest
    {
        private Query _query;

        [SetUp]
        public void Setup()
        {
            _query = new Query("RETURN 1;");
            _query.Results = new Results(new List<JToken>() { new JValue(1) });
        }

        [Test]
        public void ShouldContainQueryString()
        {
            Assert.AreEqual("RETURN 1;", _query.QueryString);
        }

        [Test]
        public void ShouldContainResults()
        {
            var actualResult = _query.Results;

            Assert.AreEqual("1", string.Join("\n", actualResult.ToNdjson()));
        }
    }
}
