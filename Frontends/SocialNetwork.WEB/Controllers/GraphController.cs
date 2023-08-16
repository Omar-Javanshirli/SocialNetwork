using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    public class GraphController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
