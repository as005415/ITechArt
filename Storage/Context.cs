using System;
using Microsoft.EntityFrameworkCore;

namespace Storage
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        
        public DbSet<PersonRequests> PersonRequests { get; set; }
        public DbSet<PropertyInfo> PropertyInfo { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyInfo>()
                .HasOne<PersonRequests>(info => info.PersonRequest)
                .WithMany(requests => requests.PropertyInfos)
                .HasForeignKey(info => info.PersonRequestId);
            

            modelBuilder.Entity<UsersPersonRequests>().HasKey(r => new {r.UserId, r.PersonRequestId});
            modelBuilder.Entity<UsersPersonRequests>().HasIndex(r => new {r.UserId, r.PersonRequestId}).IsUnique();
            
            modelBuilder.Entity<UsersPersonRequests>()
                .HasOne<Users>(user => user.User)
                .WithMany(usersPersonRequest => usersPersonRequest.UsersPersonRequests)
                .HasForeignKey(requests => requests.UserId);
            
            modelBuilder.Entity<UsersPersonRequests>()
                .HasOne<PersonRequests>(requests => requests.PersonRequest)
                .WithMany(usersPersonRequest => usersPersonRequest.UsersPersonRequests)
                .HasForeignKey(requests => requests.PersonRequestId);


            modelBuilder.Entity<UsersRoles>().HasKey(r => new {r.UserId, r.RoleId});
            modelBuilder.Entity<UsersRoles>().HasIndex(r => new {r.UserId, r.RoleId}).IsUnique();
            
            modelBuilder.Entity<UsersRoles>()
                .HasOne<Users>(user => user.User)
                .WithMany(usersRoles => usersRoles.UsersRoles)
                .HasForeignKey(user => user.UserId);
            
            modelBuilder.Entity<UsersRoles>()
                .HasOne<Roles>(role => role.Role)
                .WithMany(usersRoles => usersRoles.UsersRoles)
                .HasForeignKey(role => role.RoleId);
            
            
            modelBuilder.Entity<RolesPermissions>().HasKey(r => new {r.PermissionId, r.RoleId});
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