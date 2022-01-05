namespace Medea.Client.Adapter
{
    public class InMemoryAdapter : IAdapter
    {
        private dynamic _queryService;

        public InMemoryAdapter(dynamic queryService)
        {
            _queryService = queryService;
        }

        public void Execute(Query query)
        {
            dynamic results = _queryService.Execute(query.QueryString);

            query.Results = new Results(results);
        }
    }
}