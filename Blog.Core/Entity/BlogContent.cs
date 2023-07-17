using System.Reflection.Metadata.Ecma335;

namespace Blog.Core.Entity
{
    public class BlogContent : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}
