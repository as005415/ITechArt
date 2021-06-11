using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models;
using WebApplication.Models.DbModels;

namespace WebApplication.ModelsConfig
{
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Login).HasMaxLength(255);
            builder.Property(p => p.Password).HasMaxLength(255);
        }
    }
}