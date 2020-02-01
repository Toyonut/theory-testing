using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace theory_testing.Models
{
    public class StorageContext : DbContext
    {
        private ISettingsCodex _configuration;
        public StorageContext(ISettingsCodex configuration)
        {
            _configuration = configuration;
        }

        public DbSet<StoredString> StoredStrings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(_configuration.GetConnectionString());

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
