using Blog.Core.Entity;
using Blog.Core.Repositories;
using Blog.Repository.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories
{
    public class UserCredentialsRepository : GenericRepositories<UserCredentials>, IUserCredentialsRepository 
    {
        public UserCredentialsRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
