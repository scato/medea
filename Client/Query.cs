namespace Medea.Client
{
    public class Query
    {
        public string QueryString { get; set; }
        public Results Results { get; set; }

        public Query(string queryString)
        {
            QueryString = queryString;
        }
    }
}
