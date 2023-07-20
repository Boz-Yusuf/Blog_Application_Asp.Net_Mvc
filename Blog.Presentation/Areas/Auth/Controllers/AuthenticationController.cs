using Blog.Core.DTOs;
using Blog.Core.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

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
        public async Task<IActionResult>  Login(LogInCredentialsDto LogIncredentialsDto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userCredentialsService.ValidateUserCredentialsAsync(LogIncredentialsDto);

            if (result == false)
                ModelState.AddModelError("","User Not Found");
            else
            {
               var principal =  _userCredentialsService.LogIn(LogIncredentialsDto);
               await HttpContext.SignInAsync(principal.CookieName, principal.ClaimsPrincipal);
               return Redirect("/User/Blog");
            }


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


            await _userCredentialsService.SignUpAsync(signUpCredentialsDto);
            return Redirect("/Auth/Authentication/Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return Redirect("/User/Blog");
        }




    }
}
