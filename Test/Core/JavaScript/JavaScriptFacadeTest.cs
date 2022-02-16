using Medea.Core.JavaScript;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Medea.Test.Core.JavaScript
{
    public class JavaScriptServiceTest
    {
        [Test]
        public void ShouldEvaluateExpressions()
        {
            var service = new JavaScriptFacade();
            var input = new JObject(new JProperty("i", new JValue(1)));

            var output = service.Evaluate("i + 1", input);

            Assert.AreEqual(new JValue(2), output);
        }
    }
}
