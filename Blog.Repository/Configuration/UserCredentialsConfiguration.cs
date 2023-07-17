using Blog.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Configuration
{
    internal class UserCredentialsConfiguration : IEntityTypeConfiguration<UserCredentials>
    {

        public void Configure(EntityTypeBuilder<UserCredentials> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PasswordHashed).IsRequired().HasMaxLength(64);


            builder.HasOne(x => x.User).WithOne(x => x.UserCredentials).HasForeignKey<UserCredentials>(x => x.UserId);
        }
    }
}
