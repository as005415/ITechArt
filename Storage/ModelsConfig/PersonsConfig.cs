using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Models;

namespace Storage.ModelsConfig
{
    public class PersonsConfig : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
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