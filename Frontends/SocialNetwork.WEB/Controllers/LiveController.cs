using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    public class LiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
