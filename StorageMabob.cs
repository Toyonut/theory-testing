using System.Collections.Generic;
using theory_testing.PersistenceProviders;

namespace theory_testing
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
