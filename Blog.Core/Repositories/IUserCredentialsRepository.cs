﻿using Blog.Core.DTOs;
using Blog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface IUserCredentialsRepository : IGenericRepository<UserCredentials>
    {
        Task<bool> ValidateUserCredentials(LogInCredentialsDto logInCredentialsDto);
    }
}
