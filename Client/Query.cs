namespace Medea.Client
{
    public class Query
    {
        public readonly string QueryString;
        public Results Results { get; set; }

        public Query(string queryString)
        {
            QueryString = queryString;
        }
    }
}
