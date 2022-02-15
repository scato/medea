using System;
using System.IO;
using System.Reflection;

namespace Medea.Client.Adapter
{
    public class AdapterFactory : IAdapterFactory
    {
        public IAdapter Create(string uriString)
        {
            var uri = new Uri(uriString);

            switch (uri.Scheme)
            {
                case "data":
                    // Search for Medea.Core.dll in the same location as Medea.Client.dll
                    var basePath = Path.GetDirectoryName(typeof(AdapterFactory).Assembly.Location);
                    var coreAssembly = Assembly.LoadFrom(Path.Join(basePath, "Medea.Core.dll"));

                    dynamic queryService = coreAssembly.CreateInstance("Medea.Core.Service.QueryService");

                    return new InMemoryAdapter(queryService);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
