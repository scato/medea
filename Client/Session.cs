using Medea.Client.Adapter;

namespace Medea.Client
{
    public class Session
    {
        private IAdapter _adapter;

        public Session(IAdapter adapter)
        {
            _adapter = adapter;
        }

        public static Session Create(string uri)
        {
            var factory = new AdapterFactory();

            return new Session(factory.Create(uri));
        }

        public Query Query(string queryString)
        {
            var query = new Query(queryString);

            _adapter.Execute(query);

            return query;
        }
    }
}
