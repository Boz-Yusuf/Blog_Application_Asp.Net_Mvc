using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entity;
using Blog.Core.Repositories;
using Blog.Core.Service;
using Blog.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Service
{
    public class UserCredentialsService : Service<UserCredentials>, IUserCredentialsService
    {
        private readonly IUserCredentialsRepository _userCredentialsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserCredentialsService(IGenericRepository<UserCredentials> repository, IUnitOfWork unitOfWork,IMapper mapper, IUserCredentialsRepository userCredentialsRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _userCredentialsRepository = userCredentialsRepository;
            _unitOfWork = unitOfWork;
      
        }

        public async Task SignUp(SignUpCredentialsDto signUpCredentialsDto)
        {
            var hashedPassword = ComputeSha256Hash(signUpCredentialsDto.Password);
            UserCredentials userMapped = _mapper.Map<UserCredentials>(signUpCredentialsDto);
            userMapped.PasswordHashed = hashedPassword;


            await _userCredentialsRepository.AddAsync(userMapped);
            await _unitOfWork.CommitAsync();
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
