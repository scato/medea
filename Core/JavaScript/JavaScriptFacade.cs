using Jint;
using Jint.Native;
using Jint.Native.Json;
using Newtonsoft.Json.Linq;

namespace Medea.Core.JavaScript
{
    public class JavaScriptFacade
    {
        public JToken Evaluate(string expression, JToken input)
        {
            var engine = new Engine();
            var parser = new JsonParser(engine);
            var serializer = new JsonSerializer(engine);

            if (input is JObject inputObject)
            {
                foreach (var prop in inputObject)
                {
                    var propValueJson = prop.Value.ToString(Newtonsoft.Json.Formatting.None);
                    engine.SetValue(prop.Key, parser.Parse(propValueJson));
                }
            }

            var output = engine.Execute(expression).GetCompletionValue();
            var outputJson = serializer.Serialize(output, Undefined.Instance, Undefined.Instance).ToString();

            return JToken.Parse(outputJson);
        }
    }
}
