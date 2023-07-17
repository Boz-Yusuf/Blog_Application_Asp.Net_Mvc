using Blog.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Repository.Configuration
{
    internal class BlogContentConfiguration : IEntityTypeConfiguration<BlogContent>
    {
        public void Configure(EntityTypeBuilder<BlogContent> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Content).IsRequired();



            builder.HasOne(x => x.Category).WithMany(x => x.BlogContexts).HasForeignKey(x => x.CategoryId);
        }
    }
}
