using System;
using System.Linq;
using Medea.Core.Service;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Medea.Test.Core.Service
{
    public class DatabaseServiceTest
    {
        [Test]
        public void ShouldInitializeEmptyDatabase()
        {
            var factory = new InMemoryServiceFactory();
            var service = factory.CreateDatabaseService();

            Assert.Throws<ArgumentException>(() => {
                factory.CreateDataStorageFacade().Scan("default");
            });

            service.Initialize();

            Assert.DoesNotThrow(() => {
                factory.CreateDataStorageFacade().Scan("default");
            });
        }

        [Test]
        public void ShouldInitializeDatabaseWithNdjsonData()
        {
            var factory = new InMemoryServiceFactory();
            var service = factory.CreateDatabaseService();

            service.Initialize("application/x-ndjson", "{\"year\":\"1993\"}\n{\"year\":\"1995\"}");

            var results = factory.CreateDataStorageFacade().Scan("default")
                .Select(r => r.ToString(Formatting.None))
                .ToArray();

            Assert.AreEqual("{\"year\":\"1993\"}", results[0]);
            Assert.AreEqual("{\"year\":\"1995\"}", results[1]);
        }
    }
}
