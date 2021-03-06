﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Models;

namespace Storage.ModelsConfig
{
    public class UsersRolesConfig : IEntityTypeConfiguration<UsersRoles>
    {
        public void Configure(EntityTypeBuilder<UsersRoles> builder)
        {
            builder.HasIndex(r => new {r.UserId, r.RoleId}).IsUnique();

            builder
                .HasOne<UserModel>(user => user.UserModel)
                .WithMany(usersRoles => usersRoles.UsersRoles)
                .HasForeignKey(user => user.UserId);

            builder
                .HasOne<Roles>(role => role.Role)
                .WithMany(usersRoles => usersRoles.UsersRoles)
                .HasForeignKey(role => role.RoleId);
        }
    }
}