using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class UserCredentialsDto : BaseDto
    {
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public int? UserId { get; set; }
    }
}
