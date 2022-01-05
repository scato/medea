using NUnit.Framework;
using Medea.Client;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace Medea.Test.Client
{
    public class ResultsTest
    {
        private List<JsonDocument> _list;

        [SetUp]
        public void SetUp()
        {
            _list = new List<JsonDocument>() { JsonDocument.Parse("{\"id\":1}"), JsonDocument.Parse("{\"id\":2}") };
        }

        [Test]
        public void ShouldProvideGenericEnumerator()
        {
            IEnumerable<JsonDocument> results = new Results(_list);

            Assert.IsInstanceOf<IEnumerator<JsonDocument>>(results.GetEnumerator());
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
