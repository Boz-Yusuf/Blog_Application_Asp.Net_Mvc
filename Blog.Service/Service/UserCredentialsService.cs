using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entity;
using Blog.Core.Repositories;
using Blog.Core.Service;
using Blog.Core.UnitOfWorks;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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

        public async Task SignUpAsync(SignUpCredentialsDto signUpCredentialsDto)
        {
            var hashedPassword = ComputeSha256Hash(signUpCredentialsDto.Password);
            UserCredentials userMapped = _mapper.Map<UserCredentials>(signUpCredentialsDto);
            userMapped.PasswordHashed = hashedPassword;


            await _userCredentialsRepository.AddAsync(userMapped);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> ValidateUserCredentialsAsync(LogInCredentialsDto logInCredentialsDto)
        {
            logInCredentialsDto.Password = ComputeSha256Hash(logInCredentialsDto.Password);

            bool result =  await _userCredentialsRepository.ValidateUserCredentials(logInCredentialsDto);


            return result;  
        }


        public PrincipleDto LogIn(LogInCredentialsDto logInCredentialsDto)
        {

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , "user"),
                    new Claim(ClaimTypes.Email, logInCredentialsDto.Email),
                    new Claim("User", "true")
                };

            if (logInCredentialsDto.Email == "boz.yusuf3548@gmail.com")
                claims.Add(new Claim("Admin", "true"));

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            PrincipleDto principle = new PrincipleDto {CookieName="MyCookieAuth",ClaimsPrincipal=claimsPrincipal };
            return principle;
            //await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal, authProperties);

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
