using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ModelsConfig
{
    public class EstateConfig : IEntityTypeConfiguration<Estate>
    {
        public void Configure(EntityTypeBuilder<Estate> builder)
        {
            builder.Property(p => p.Address).HasMaxLength(255);
            builder.Property(p => p.TypeOfProperty).HasMaxLength(255);
            builder.Property(p => p.StateOfProperty).HasMaxLength(255);

            builder
                .HasMany(r => r.Persons)
                .WithOne(r => r.Estate);
        }
    }
}