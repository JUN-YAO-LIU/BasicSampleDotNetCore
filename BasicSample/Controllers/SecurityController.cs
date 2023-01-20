using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}