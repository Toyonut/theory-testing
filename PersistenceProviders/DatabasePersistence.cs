using System.Collections.Generic;
using db_app.Models;
using System.Linq;
using System;

namespace db_app.PersistenceProviders
{
    public class DatabasePersistence : IPersistenceProvider
    {
        public DatabasePersistence()
        {
        }

        public void AddItem(string item)
        {
            using (var db = new StorageContext())
            {
                var i = new StoredString()
                {
                    stringToStore = item
                };

                try
                {
                    db.Add(i);
                    db.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    // swallow this exception, this seems like the recommended way to do this so we don't get race conditions between checking an item exists and writing it...
                    Console.WriteLine($"{item} already exists in DB.");
                }
            }
        }

        public void DeleteItem(string item)
        {
            using (var db = new StorageContext())
            {
                var i = new StoredString()
                {
                    stringToStore = item
                };
                db.Remove(i);
                db.SaveChanges();
            }
        }

        public List<string> ReturnItems()
        {
            using (var db = new StorageContext())
            {
                var stored = db.StoredStrings
                    .OrderBy(s => s.Id)
                    .Select(s => s.stringToStore)
                    .ToList();

                return stored;
            }
        }
    }
}
