using Microsoft.EntityFrameworkCore;

namespace Migrator.DataAccess
{
    public class AppDBContext : DbContext
    {
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.ClientContacts> ClientContacts { get; set; }
        public DbSet<Models.ClientPersonalInfo> ClientPersonalInfo { get; set; }
        public DbSet<Models.Service> Trainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine("../", "Clients.db");
            string connectionString = $"Filename={dbPath}";
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Client>()
                .HasOne(c => c.Contacts)
                .WithOne(cc => cc.Client)
                .HasForeignKey<Models.ClientContacts>(cc => cc.ID);

            modelBuilder.Entity<Models.Client>()
                .HasOne(c => c.PersonalInfo)
                .WithOne(pi => pi.Client)
                .HasForeignKey<Models.ClientPersonalInfo>(pi => pi.ID);

            modelBuilder.Entity<Models.Client>()
                .HasMany(c => c.ServiceList)
                .WithMany(t => t.Clients);

            modelBuilder.Entity<Models.ClientContacts>()
                .HasIndex(cc => cc.EmailAddress)
                .IsUnique();

            modelBuilder.Entity<Models.ClientContacts>()
                .HasIndex(cc => cc.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Models.Service>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
