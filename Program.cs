﻿using System;
using db_app.PersistenceProviders;
using db_app.Models;

namespace db_app
{
    class Program
    {
        static void Main(string[] args)
        {
            var persistenceType = new DatabasePersistence();
            var storageMabob = new StorageMabob(persistenceType);

            string[] items = { "foo", "bar", "baz", "foz", "buz", "biz" };

            foreach (var item in items)
            {
                storageMabob.AddItem(item);
            }

            var allItems = storageMabob.ReturnItems();

            foreach(var item in allItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}