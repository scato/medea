using NUnit.Framework;
using Medea.Client;
using Moq;

namespace Medea.Test.Client
{
    public class SessionTest
    {
        private Mock<IAdapter> _adapterSpy;
        private Session _session;

        [SetUp]
        public void Setup()
        {
            _adapterSpy = new Mock<IAdapter>();
            _session = new Session(_adapterSpy.Object);
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
