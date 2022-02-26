using System;
using Medea.Client.Adapter;
using NUnit.Framework;

namespace Medea.Test.Client.Adapter
{
    public class DataUriExtensionsTest
    {
        [Test]
        public void ShouldExtractMediaType()
        {
            Assert.AreEqual("text/plain;charset=US-ASCII", new Uri("data:foo").GetMediaType());
            Assert.AreEqual("text/plain;charset=US-ASCII", new Uri("data:,").GetMediaType());
            Assert.AreEqual("application/json", new Uri("data:application/json,%5B%5D").GetMediaType());
            Assert.AreEqual("application/json;base64", new Uri("data:application/json;base64,W10=").GetMediaType());
            Assert.AreEqual("application/json;charset=UTF-8;base64", new Uri("data:application/json;charset=UTF-8;base64,W10=").GetMediaType());
        }

        [Test]
        public void ShouldExtractContent()
        {
            Assert.AreEqual("foo", new Uri("data:foo").GetContent());
            Assert.AreEqual("", new Uri("data:,").GetContent());
            Assert.AreEqual("[]", new Uri("data:application/json,%5B%5D").GetContent());
            Assert.AreEqual("[]\n[]", new Uri("data:application/x-ndjson,%5B%5D%0A%5B%5D").GetContent());
            Assert.AreEqual("[]", new Uri("data:application/json;base64,W10=").GetContent());
            Assert.AreEqual("[]", new Uri("data:application/json;charset=UTF-8;base64,W10=").GetContent());
            Assert.AreEqual("[\"é\"]", new Uri("data:application/json;charset=UTF-8;base64,WyLDqSJd").GetContent());
            Assert.AreEqual("[\"é\"]", new Uri("data:application/json;charset=ISO-8859-1;base64,WyLpIl0=").GetContent());
        }
    }
}
