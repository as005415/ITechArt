using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ModelsConfig
{
    public class PersonRequestConfiguration : IEntityTypeConfiguration<PersonRequest>
    {
        public void Configure(EntityTypeBuilder<PersonRequest> builder)
        {
            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonRequests);
        }
    }
}