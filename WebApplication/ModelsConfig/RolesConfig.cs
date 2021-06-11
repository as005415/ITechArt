using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models;
using WebApplication.Models.DbModels;

namespace WebApplication.ModelsConfig
{
    public class RolesConfig : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.Property(p => p.RoleName).HasMaxLength(255);
        }
    }
}