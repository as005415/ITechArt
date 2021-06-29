using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ModelsConfig
{
    public class NormConfiguration : IEntityTypeConfiguration<Norm>
    {
        public void Configure(EntityTypeBuilder<Norm> builder)
        {
            builder.Property(p => p.AdministrativeUnit)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}