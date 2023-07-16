using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public class UserCredentials : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
