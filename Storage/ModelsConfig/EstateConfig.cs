using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Models;

namespace Storage.ModelsConfig
{
    public class EstateConfig : IEntityTypeConfiguration<Estate>
    {
        public void Configure(EntityTypeBuilder<Estate> builder)
        {
            builder.Property(p => p.Address).HasMaxLength(255);
            builder.Property(p => p.TypeOfProperty).HasMaxLength(255);
            builder.Property(p => p.StateOfProperty).HasMaxLength(255);
            
            builder
                .HasOne(r => r.Person)
                .WithMany(r => r.Estates)
                .HasForeignKey(r => r.PersonId);
        }
    }
}