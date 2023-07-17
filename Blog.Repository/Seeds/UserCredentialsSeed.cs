using Blog.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Repository.Seeds
{
    internal class UserCredentialsSeed : IEntityTypeConfiguration<UserCredentials>
    {
        public void Configure(EntityTypeBuilder<UserCredentials> builder)
        {
            builder.HasData(
                new UserCredentials
                {
                    Id = 1,
                    Email = "user1@gmail.com",
                    PasswordHashed = "password",
                    CreatedDate = DateTime.UtcNow,
                    User = new User { Id = 1 ,UserName = "developer1"},
                },
                new UserCredentials
                {
                    Id = 2,
                    Email = "user2@gmail.com",
                    PasswordHashed = "password",
                    CreatedDate = DateTime.UtcNow,
                    User = new User { Id = 2, UserName = "developer2" },
                },
                new UserCredentials
                {
                    Id = 3,
                    Email = "user3@gmail.com",
                    PasswordHashed = "password",
                    CreatedDate = DateTime.UtcNow,
                    User = new User { Id = 3, UserName = "developer3" },
                });
        }
    }
}
