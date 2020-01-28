using System.Collections.Generic;

namespace db_app.PersistenceProviders
{
    public class MemoryPersistence : IPersistenceProvider
    {
        private List<string> itemsList = new List<string>();

        public void AddItem(string item)
        {
            itemsList.Add(item);
        }

        public void DeleteItem(string item)
        {
            itemsList.Remove(item);
        }

        public List<string> ReturnItems()
        {
            return itemsList;
        }
    }
}
