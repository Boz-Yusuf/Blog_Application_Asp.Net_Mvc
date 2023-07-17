using Blog.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Asp.Net Core", CreatedDate = DateTime.UtcNow },
                new Category { Id = 2, Name = "Entity Framework", CreatedDate = DateTime.UtcNow },
                new Category { Id = 3, Name = "C#", CreatedDate = DateTime.UtcNow });
        }
    }
}
