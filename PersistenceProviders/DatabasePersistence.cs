using System.Collections.Generic;
using db_app.Models;
using System.Linq;

namespace db_app.PersistenceProviders
{
    public class DatabasePersistence : IPersistenceProvider
    {
        public DatabasePersistence()
        {
            using (var db = new StorageContext())
            {
                var stored = db.StoredStrings;

                foreach (var item in stored)
                {
                    db.Remove(item);
                }

                db.SaveChanges();
            }
        }

        public void AddItem(string item)
        {
            using (var db = new StorageContext())
            {
                var i = new StoredString();
                i.stringToStore = item;
                db.Update(i);
                db.SaveChanges();
            }
        }

        public void DeleteItem(string item)
        {
            using (var db = new StorageContext())
            {
                var i = new StoredString();
                i.stringToStore = item;
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
