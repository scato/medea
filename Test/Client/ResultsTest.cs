using NUnit.Framework;
using Medea.Client;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Medea.Test.Client
{
    public class ResultsTest
    {
        private List<JToken> _list;

        [SetUp]
        public void SetUp()
        {
            _list = new List<JToken>() {
                new JObject(new JProperty("id", new JValue(1))),
                new JObject(new JProperty("id", new JValue(2)))
            };
        }

        [Test]
        public void ShouldProvideGenericEnumerator()
        {
            IEnumerable<JToken> results = new Results(_list);

            Assert.IsInstanceOf<IEnumerator<JToken>>(results.GetEnumerator());
        }

        [Test]
        public void ShouldProvideRegularEnumerator()
        {
            IEnumerable results = new Results(_list);

            Assert.IsInstanceOf<IEnumerator>(results.GetEnumerator());
        }

        [Test]
        public void ShouldBeConvertableToNdjson()
        {
            Results results = new Results(_list);

            Assert.AreEqual("{\"id\":1}\n{\"id\":2}", results.ToNdjson());
        }
    }
}
