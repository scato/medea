using NUnit.Framework;
using Medea.Client;
using Moq;

namespace Medea.Test.Client
{
    public class SessionTest
    {
        private Mock<IAdapterFactory> _factoryFake;
        private Mock<IAdapter> _adapterSpy;
        private Session _session;

        [SetUp]
        public void Setup()
        {
            _factoryFake = new Mock<IAdapterFactory>();
            _adapterSpy = new Mock<IAdapter>();

            _factoryFake.Setup(adapter => adapter.Create("data:[]")).Returns(_adapterSpy.Object);

            _session = new Session("data:[]", _factoryFake.Object);
        }

        [Test]
        public void ShouldExecuteQueries()
        {
            var query = _session.Query("RETURN 1;");

            Assert.IsInstanceOf<Query>(query);
            _adapterSpy.Verify(adapter => adapter.Execute(query));
        }
    }
}
