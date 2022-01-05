namespace Medea.Client
{
    public interface IAdapterFactory
    {
        public IAdapter Create(string uri);
    }
}
