using Blog.Core.DTOs;
using Blog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Service
{
    public interface IUserCredentialsService : IService<UserCredentials>
    {
        public Task SignUp(SignUpCredentialsDto signUpCredentialsDto);
    }
}
