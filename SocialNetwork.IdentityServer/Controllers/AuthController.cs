using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.IdentityServer.Core.Models;
using SocialNetwork.IdentityServer.Core.Models.Input;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.IdentityServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpInput request)
        {
            ApplicationUser applicationUser = new ApplicationUser();

            applicationUser.UserName = request.Username;
            applicationUser.Email = request.Email;

            var result = await this.userManager.CreateAsync(applicationUser, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(x => x.Description));

            return Ok("signup calisti");
        }
    }
}
