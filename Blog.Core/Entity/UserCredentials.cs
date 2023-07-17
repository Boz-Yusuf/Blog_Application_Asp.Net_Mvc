namespace Blog.Core.Entity
{
    public class UserCredentials : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
