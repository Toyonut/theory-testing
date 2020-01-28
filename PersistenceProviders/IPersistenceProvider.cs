using System.Collections.Generic;

namespace db_app.PersistenceProviders
{
    public interface IPersistenceProvider
    {
        void AddItem(string item);

        void DeleteItem(string item);

        List<string> ReturnItems();
    }
}