using NUnit.Framework;

namespace Medea.Test.Client.Adapter
{
    public class UriTest
    {
        [Test]
        public void ShouldExtendSystemUri()
        {
            var uri = new Medea.Client.Adapter.Uri("about:blank");

            Assert.IsInstanceOf<System.Uri>(uri);
        }

        [Test]
        public void ShouldRecognizeDataUris()
        {
            var uri = new Medea.Client.Adapter.Uri("data:[]");

            Assert.True(uri.IsData);
        }
    }
}
