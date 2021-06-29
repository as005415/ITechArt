using System.Reflection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<PersonRequest> PersonRequests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Norm> Norms { get; set; }
    }
}