using Blog.Core.DTOs;
using Blog.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Presentation.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthenticationController : Controller
    {
        private readonly IUserCredentialsService _userCredentialsService;
        public AuthenticationController(IUserCredentialsService userCredentialsService)
        {
            _userCredentialsService = userCredentialsService;
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogInCredentialsDto credentialsDto)
        {
            if (!ModelState.IsValid)
                return View();

            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpCredentialsDto signUpCredentialsDto )
        {
            if (signUpCredentialsDto.Password != signUpCredentialsDto.PasswordAgain)
                ModelState.AddModelError("", "Passwords do not match");



            if (!ModelState.IsValid)
                return View();


            await _userCredentialsService.SignUp(signUpCredentialsDto);
            return View();
        }
    }
}
