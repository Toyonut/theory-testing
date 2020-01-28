using System.Collections.Generic;
using db_app.PersistenceProviders;

namespace db_app
{
    public class StorageMabob
    {
        private readonly IPersistenceProvider _persistenceLayer;
        public StorageMabob(IPersistenceProvider persistenceLayer)
        {
            _persistenceLayer = persistenceLayer;
        }

        public void AddItem(string item)
        {
            _persistenceLayer.AddItem(item);
        }

        public void DeleteItem(string item)
        {
            _persistenceLayer.DeleteItem(item);
        }

        public List<string> ReturnItems()
        {
            return _persistenceLayer.ReturnItems();
        }
    }
}
