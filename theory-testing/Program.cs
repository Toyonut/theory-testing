using System;
using theory_testing.PersistenceProviders;
using theory_testing.Models;
using Autofac;

namespace theory_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<DatabasePersistence>().As<IPersistenceProvider>();
            containerBuilder.RegisterType<SettingsCodex>().As<ISettingsCodex>();
            var Container = containerBuilder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var configuration = scope.Resolve<ISettingsCodex>();

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
