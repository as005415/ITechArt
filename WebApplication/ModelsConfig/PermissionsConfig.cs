using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models;
using WebApplication.Models.DbModels;

namespace WebApplication.ModelsConfig
{
    public class PermissionsConfig : IEntityTypeConfiguration<Permissions>
    {
        public void Configure(EntityTypeBuilder<Permissions> builder)
        {
            builder.Property(p => p.PermissionDescription).HasMaxLength(255);
        }
    }
}