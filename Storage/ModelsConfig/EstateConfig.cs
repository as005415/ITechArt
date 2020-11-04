using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Models;

namespace Storage.ModelsConfig
{
    public class EstateConfig : IEntityTypeConfiguration<Estate>
    {
        public void Configure(EntityTypeBuilder<Estate> builder)
        {
            builder
                .HasOne(r => r.Person)
                .WithMany(r => r.Estates)
                .HasForeignKey(r => r.PersonId);
        }
    }
}