using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Medea.Client
{
    public class Results : IEnumerable<JToken>
    {
        private IEnumerable<JToken> _inner;

        public Results(IEnumerable<JToken> inner)
        {
            _inner = inner;
        }

        public IEnumerator<JToken> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        public string ToNdjson()
        {
            return string.Join("\n", _inner.Select(record => record.ToString(Formatting.None)));
        }
    }
}
