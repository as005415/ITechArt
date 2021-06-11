using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models;
using WebApplication.Models.DbModels;

namespace WebApplication.ModelsConfig
{
    public class UsersRolesConfig : IEntityTypeConfiguration<UsersRoles>
    {
        public void Configure(EntityTypeBuilder<UsersRoles> builder)
        {
            builder.HasIndex(r => new {r.UserId, r.RoleId}).IsUnique();

            builder
                .HasOne<User>(user => user.User)
                .WithMany(usersRoles => usersRoles.UsersRoles)
                .HasForeignKey(user => user.UserId);

            builder
                .HasOne<Roles>(role => role.Role)
                .WithMany(usersRoles => usersRoles.UsersRoles)
                .HasForeignKey(role => role.RoleId);
        }
    }
}