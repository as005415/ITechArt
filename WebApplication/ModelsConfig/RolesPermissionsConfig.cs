using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models;
using WebApplication.Models.DbModels;

namespace WebApplication.ModelsConfig
{
    public class RolesPermissionsConfig : IEntityTypeConfiguration<RolesPermissions>
    {
        public void Configure(EntityTypeBuilder<RolesPermissions> builder)
        {
            builder.HasIndex(r => new {r.PermissionId, r.RoleId}).IsUnique();

            builder
                .HasOne<Permissions>(permissions => permissions.Permission)
                .WithMany(rolesPermissions => rolesPermissions.RolesPermissions)
                .HasForeignKey(permissions => permissions.PermissionId);

            builder
                .HasOne<Roles>(role => role.Role)
                .WithMany(rolesPermissions => rolesPermissions.RolesPermissions)
                .HasForeignKey(role => role.RoleId);
        }
    }
}