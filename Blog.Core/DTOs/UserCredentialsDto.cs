namespace Blog.Core.DTOs
{
    public class UserCredentialsDto : BaseDto
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public int? UserId { get; set; }
    }
}
