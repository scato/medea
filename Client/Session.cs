using Medea.Client.Adapter;

namespace Medea.Client
{
    public class Session
    {
        private IAdapter _adapter;

        public Session(string uri, IAdapterFactory factory)
        {
            _adapter = factory.Create(uri);
        }

        public Session(string uri) : this(uri, new AdapterFactory())
        {
        }

        public Query Query(string queryString)
        {
            var query = new Query(queryString);

            _adapter.Execute(query);

            return query;
        }
    }
}
