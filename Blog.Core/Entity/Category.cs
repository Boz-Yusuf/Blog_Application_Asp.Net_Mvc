namespace Blog.Core.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BlogContent> BlogContexts { get; set; }
    }
}
