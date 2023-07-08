using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Web.Core.Services;

namespace SocialNetwork.WEB.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}
