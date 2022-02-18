using System.Linq;
using Medea.Core.FileStorage;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Medea.Test.Core.FileStorage
{
    public class FileStorageFacadeTest
    {
        [Test]
        public void ShouldListLocalFiles()
        {
            var fileStorage = new FileStorageFacade();

            var fileNames = fileStorage.List("Fixtures/**").ToArray();

            Assert.AreEqual(new[] { "Fixtures/Examples/example.txt" }, fileNames);
        }

        [Test]
        public void ShouldReadLocalFile()
        {
            var fileStorage = new FileStorageFacade();

            var contents = fileStorage.Read("Fixtures/Examples/example.txt", FileStorageFormat.RAW).ToArray();

            for (var i = 0; i < contents.Length; i++)
            {
                if (contents[i] is JValue t && t.Value is string s)
                {
                    contents[i] = new JValue(s.Replace("\r", ""));
                }
            }

            Assert.AreEqual(new [] { new JValue("foo\nbar\n") }, contents);
        }
    }
}
