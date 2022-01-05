using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Medea.Client
{
    public class Results : IEnumerable<JsonDocument>
    {
        private IEnumerable<JsonDocument> _inner;

        public Results(IEnumerable<JsonDocument> inner)
        {
            _inner = inner;
        }

        public IEnumerator<JsonDocument> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        public string ToNdjson()
        {
            return string.Join("\n", _inner.Select(row => row.RootElement.ToString()));
        }
    }
}
