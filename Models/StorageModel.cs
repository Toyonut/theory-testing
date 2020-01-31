using Microsoft.EntityFrameworkCore;

namespace db_app.Models
{
    public class StorageContext : DbContext
    {
        public DbSet<StoredString> StoredStrings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Server=localhost; Database=testdb; UserName=testuser; Password=testpassword;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoredString>()
                .HasIndex(s => s.stringToStore)
                .IsUnique();
        }
    }

    public class StoredString
    {
        public int Id {get; set; }
        public string stringToStore {get; set; }
    }
}
