using System;
using theory_testing.PersistenceProviders;
using theory_testing.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Autofac;

namespace theory_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            var configuration = configBuilder.Build();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<DatabasePersistence>().As<IPersistenceProvider>();
            var Container = containerBuilder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                Func<StorageContext> contextFactory = () => new StorageContext(configuration);

                var dbContext = new NamedParameter("storageContextFactory", contextFactory);
                var persistenceType = scope.Resolve<IPersistenceProvider>(dbContext);
                var storageMabob = new StorageMabob(persistenceType);

                string[] items = { "foo", "bar", "baz", "foz", "buz", "biz" };

                foreach (var item in items)
                {
                    storageMabob.AddItem(item);
                }

                var allItems = storageMabob.ReturnItems();

                foreach (var item in allItems)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
