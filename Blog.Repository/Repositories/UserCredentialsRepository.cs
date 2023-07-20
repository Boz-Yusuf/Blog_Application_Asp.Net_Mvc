using Blog.Core.DTOs;
using Blog.Core.Entity;
using Blog.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository.Repositories
{
    public class UserCredentialsRepository : GenericRepositories<UserCredentials>, IUserCredentialsRepository 
    {
        private readonly AppDbContext _context;
        private readonly DbSet<UserCredentials> _dbSet;
        public UserCredentialsRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<UserCredentials>();
        }

        public async Task<bool> ValidateUserCredentials(LogInCredentialsDto logInCredentialsDto)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == logInCredentialsDto.Email && x.PasswordHashed == logInCredentialsDto.Password);
            if (user == null)
                return false;
            
            return true;
        }
    }
}
