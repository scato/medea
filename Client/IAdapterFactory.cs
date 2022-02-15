namespace Medea.Client
{
    public interface IAdapterFactory
    {
        IAdapter Create(string uri);
    }
}
