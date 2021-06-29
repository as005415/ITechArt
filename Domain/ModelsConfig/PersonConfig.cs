using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.ModelsConfig
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(255);
            builder.Property(p => p.LastName).HasMaxLength(255);
            builder.Property(p => p.MiddleName).HasMaxLength(255);
            builder.Property(p => p.PassportId).HasMaxLength(14);
            builder.Property(p => p.AdministrativeUnit).HasMaxLength(255);
            builder.Property(p => p.PhoneNumber).HasMaxLength(13);
        }
    }
}