using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ModelsConfig
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasIndex(r => new {r.PermissionId, r.RoleId}).IsUnique();

            builder
                .HasOne<Permission>(permissions => permissions.Permission)
                .WithMany(rolesPermissions => rolesPermissions.RolePermission)
                .HasForeignKey(permissions => permissions.PermissionId);

            builder
                .HasOne<Role>(role => role.Role)
                .WithMany(rolesPermissions => rolesPermissions.RolePermission)
                .HasForeignKey(role => role.RoleId);
        }
    }
}