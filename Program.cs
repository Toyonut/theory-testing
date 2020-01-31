using System;
using theory_testing.PersistenceProviders;
using theory_testing.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace theory_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            Func<StorageContext> contextFactory = () => new StorageContext(configuration);
            var persistenceType = new DatabasePersistence(contextFactory);
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
