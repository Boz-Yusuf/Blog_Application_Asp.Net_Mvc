using Blog.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Repository.Seeds
{
    internal class CommentSeed : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment
                {
                    Id = 1,
                    BlogContentId = 1,
                    Content = "1 Lorem ipsum dolor sit amet.",
                    CreatedDate = DateTime.UtcNow,
                    UserId = 1,
                },
                new Comment
                {
                    Id = 2,
                    BlogContentId = 2,
                    Content = "2 Lorem ipsum dolor sit amet.",
                    CreatedDate = DateTime.UtcNow,
                    UserId = 2,
                },
                new Comment
                {
                    Id = 3,
                    BlogContentId = 3,
                    Content = "3 Lorem ipsum dolor sit amet.",
                    CreatedDate = DateTime.UtcNow,
                    UserId = 2,
                });
        }
    }
}
