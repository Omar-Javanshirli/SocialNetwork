using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.IdentityServer.Core.ControllerBases;
using SocialNetwork.IdentityServer.Core.Models;
using SocialNetwork.IdentityServer.Core.Models.Input;
using SocialNetwork.IdentityServer.Core.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.IdentityServer.Controllers
{
    public class AuthController : CustomBaseController
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpInput request)
        {
            return CreateActionResult(await _authenticationService.SignUpAsync(request));
        }
    }
}
