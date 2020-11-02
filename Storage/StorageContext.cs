using Microsoft.EntityFrameworkCore;

namespace Storage
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
        }
        
        public DbSet<PersonRequests> PersonRequests { get; set; }
        public DbSet<Estate> PropertyInfo { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estate>()
                .HasOne<Persons>(r => r.Person)
                .WithMany(r => r.Estates)
                .HasForeignKey(r => r.PersonId);
            

            modelBuilder.Entity<UsersPersonRequests>().HasIndex(r => new {r.UserId, r.PersonRequestId}).IsUnique();
            
            modelBuilder.Entity<UsersPersonRequests>()
                .HasOne<Users>(user => user.User)
                .WithMany(usersPersonRequest => usersPersonRequest.UsersPersonRequests)
                .HasForeignKey(requests => requests.UserId);
            
            modelBuilder.Entity<UsersPersonRequests>()
                .HasOne<PersonRequests>(requests => requests.PersonRequest)
                .WithMany(usersPersonRequest => usersPersonRequest.UsersPersonRequests)
                .HasForeignKey(requests => requests.PersonRequestId);


            modelBuilder.Entity<UsersRoles>().HasIndex(r => new {r.UserId, r.RoleId}).IsUnique();
            
            modelBuilder.Entity<UsersRoles>()
                .HasOne<Users>(user => user.User)
                .WithMany(usersRoles => usersRoles.UsersRoles)
                .HasForeignKey(user => user.UserId);
            
            modelBuilder.Entity<UsersRoles>()
                .HasOne<Roles>(role => role.Role)
                .WithMany(usersRoles => usersRoles.UsersRoles)
                .HasForeignKey(role => role.RoleId);
            
            
            modelBuilder.Entity<RolesPermissions>().HasIndex(r => new {r.PermissionId, r.RoleId}).IsUnique();

            modelBuilder.Entity<RolesPermissions>()
                .HasOne<Permissions>(permissions => permissions.Permission)
                .WithMany(rolesPermissions => rolesPermissions.RolesPermissions)
                .HasForeignKey(permissions => permissions.PermissionId);
            
            modelBuilder.Entity<RolesPermissions>()
                .HasOne<Roles>(role => role.Role)
                .WithMany(rolesPermissions => rolesPermissions.RolesPermissions)
                .HasForeignKey(role => role.RoleId);
        }
    }
}