using System;
using Medea.Core.Service;
using NUnit.Framework;

namespace Medea.Test.Core.Service
{
    public class DatabaseServiceTest
    {
        [Test]
        public void ShouldInitializeDatabase()
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
    }
}
