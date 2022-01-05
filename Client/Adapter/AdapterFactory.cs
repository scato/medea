using System;
using System.IO;
using System.Reflection;

namespace Medea.Client.Adapter
{
    public class AdapterFactory : IAdapterFactory
    {
        public IAdapter Create(string uriString)
        {
            var uri = new Medea.Client.Adapter.Uri(uriString);

            if (uri.IsData)
            {
                var basePath = Path.GetDirectoryName(typeof(AdapterFactory).Assembly.Location);
                var coreAssembly = Assembly.LoadFrom(Path.Join(basePath, "Medea.Core.dll"));
                dynamic queryService = coreAssembly.CreateInstance("Medea.Core.Service.QueryService");

                return new InMemoryAdapter(queryService);
            }

            throw new NotImplementedException();
        }
    }
}
