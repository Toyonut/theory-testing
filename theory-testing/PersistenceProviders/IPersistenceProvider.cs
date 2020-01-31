using System.Collections.Generic;

namespace theory_testing.PersistenceProviders
{
    public interface IPersistenceProvider
    {
        void AddItem(string item);

        void DeleteItem(string item);

        List<string> ReturnItems();
    }
}
