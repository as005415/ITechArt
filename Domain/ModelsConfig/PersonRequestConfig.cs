using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ModelsConfig
{
    public class PersonRequestConfig : IEntityTypeConfiguration<PersonRequest>
    {
        public void Configure(EntityTypeBuilder<PersonRequest> builder)
        {
            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonRequests);
        }
    }
}