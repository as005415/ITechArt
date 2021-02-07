using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Models;

namespace Storage.ModelsConfig
{
    public class UsersConfig : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.Property(p => p.Login).HasMaxLength(255);
            builder.Property(p => p.Password).HasMaxLength(255);
        }
    }
}