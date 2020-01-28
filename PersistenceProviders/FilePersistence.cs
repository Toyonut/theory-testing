using System.Collections.Generic;
using System.IO;

namespace db_app.PersistenceProviders
{
    public class FilePersistence : IPersistenceProvider
    {
        private readonly string filePath = "./FilePersistence";

        public FilePersistence()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Create(filePath).Close();
        }

        public void AddItem(string item)
        {
            using (var file = new StreamWriter(filePath, true))
            {
                file.WriteLine(item);
            }
        }

        public void DeleteItem(string item)
        {
            var items = new List<string>(File.ReadAllLines(filePath));

            items.Remove(item);

            File.WriteAllLines(filePath, items);

        }

        public List<string> ReturnItems()
        {
            return new List<string>(File.ReadAllLines(filePath));
        }
    }
}
