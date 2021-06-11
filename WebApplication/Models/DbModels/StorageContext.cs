using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models.DbModels
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<PersonRequests> PersonRequests { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Norm> Norms { get; set; }
    }
}