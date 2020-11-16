using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Models;

namespace Storage.ModelsConfig
{
    public class NormConfig : IEntityTypeConfiguration<Norm>
    {
        public void Configure(EntityTypeBuilder<Norm> builder)
        {
            builder.Property(p => p.AdministrativeUnit).HasMaxLength(255);
        }
    }
}