namespace Blog.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int UserCredentialsId { get; set; }
        public UserCredentials UserCredentials { get; set; }
    }
}
