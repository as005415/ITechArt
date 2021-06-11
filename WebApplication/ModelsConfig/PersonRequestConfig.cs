using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models.DbModels;

namespace WebApplication.ModelsConfig
{
    public class PersonRequestConfig : IEntityTypeConfiguration<PersonRequests>
    {
        public void Configure(EntityTypeBuilder<PersonRequests> builder)
        {
            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonRequests);
        }
    }
}