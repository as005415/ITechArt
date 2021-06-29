using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ModelsConfig
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasIndex(r => new {r.UserId, r.RoleId}).IsUnique();

            builder
                .HasOne<User>(user => user.User)
                .WithMany(usersRoles => usersRoles.UserRole)
                .HasForeignKey(user => user.UserId);

            builder
                .HasOne<Role>(role => role.Role)
                .WithMany(usersRoles => usersRoles.UserRole)
                .HasForeignKey(role => role.RoleId);
        }
    }
}