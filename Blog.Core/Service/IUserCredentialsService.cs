using Blog.Core.DTOs;
using Blog.Core.Entity;

namespace Blog.Core.Service
{
    public interface IUserCredentialsService : IService<UserCredentials>
    {
        public Task SignUpAsync(SignUpCredentialsDto signUpCredentialsDto);
        public Task<bool> ValidateUserCredentialsAsync(LogInCredentialsDto logInCredentialsDto);
        public PrincipleDto LogIn(LogInCredentialsDto logInCredentialsDto);
    }
}
