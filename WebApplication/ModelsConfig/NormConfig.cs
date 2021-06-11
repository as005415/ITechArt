using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models;
using WebApplication.Models.DbModels;

namespace WebApplication.ModelsConfig
{
    public class NormConfig : IEntityTypeConfiguration<Norm>
    {
        public void Configure(EntityTypeBuilder<Norm> builder)
        {
            builder.Property(p => p.AdministrativeUnit)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}