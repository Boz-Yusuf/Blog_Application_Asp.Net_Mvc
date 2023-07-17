namespace Blog.Core.Entity
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public int likeCounter { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BlogContentId { get; set; }
        public BlogContent BlogContent { get; set; }
    }
}
