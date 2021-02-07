using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Models;

namespace Storage.ModelsConfig
{
    public class UserPersonRequestsConfig : IEntityTypeConfiguration<UsersPersonRequests>
    {
        public void Configure(EntityTypeBuilder<UsersPersonRequests> builder)
        {
            builder.HasIndex(r => new {r.UserId, r.PersonRequestId}).IsUnique();

            builder
                .HasOne<UserModel>(user => user.UserModel)
                .WithMany(usersPersonRequest => usersPersonRequest.UsersPersonRequests)
                .HasForeignKey(requests => requests.UserId);

            builder
                .HasOne<PersonRequests>(requests => requests.PersonRequest)
                .WithMany(usersPersonRequest => usersPersonRequest.UsersPersonRequests)
                .HasForeignKey(requests => requests.PersonRequestId);
        }
    }
}