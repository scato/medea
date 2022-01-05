namespace Medea.Client.Adapter
{
    public class Uri : System.Uri
    {
        public static readonly string UriSchemeData = "data";

        public Uri(string uriString) : base(uriString)
        {
        }

        public bool IsData { get { return Scheme == UriSchemeData; } }
    }
}
