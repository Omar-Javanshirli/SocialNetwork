using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Web.Core.Models.Input;
using IAuthenticationService = SocialNetwork.Web.Core.Services.IAuthenticationService;

namespace SocialNetwork.WEB.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInInput request)
        {
            if (ModelState is { IsValid: false })
                return View();

            var response = await this.authenticationService.SigninAsync(request);

            if (response is { IsSuccessful: false })
            {
                response.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(string.Empty, x);
                });

                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            var response = await this.authenticationService.LogoutAsync();

            if (response is { IsSuccessful: false })
            {
                response.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(string.Empty, x);
                });

                return View();
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
