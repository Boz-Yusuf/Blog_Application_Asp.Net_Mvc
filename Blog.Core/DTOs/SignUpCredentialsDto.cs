using System.ComponentModel.DataAnnotations;

namespace Blog.Core.DTOs
{
    public class SignUpCredentialsDto
    {

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password{ get; set; }

        [Display(Name = "Password Again")]
        public string PasswordAgain { get; set; }
    }
}
