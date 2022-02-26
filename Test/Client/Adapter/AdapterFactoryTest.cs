using NUnit.Framework;
using Medea.Client.Adapter;
using System;

namespace Medea.Test.Client.Adapter
{
    public class AdapterFactoryTest
    {
        private AdapterFactory _adapterFactory;

        [SetUp]
        public void SetUp()
        {
            _adapterFactory = new AdapterFactory();
        }

        [Test]
        public void ShouldNotAcceptInvalidUri()
        {
            Assert.Throws<UriFormatException>(() => {
                _adapterFactory.Create("thisisaninvaliduri");
            });
        }

        [Test]
        public void ShouldCreateInMemoryAdapterForDataUri()
        {
            var adapter = _adapterFactory.Create("data:application/x-ndjson;base64,eyJmb28iOiAiYmFyIn0=");

            Assert.IsInstanceOf<InMemoryAdapter>(adapter);
        }
    }
}
