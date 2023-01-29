using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Validation()
        {
            return View();
        }

        public IActionResult Cors()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CSRF()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CSRF(string name)
        {
            return View();
        }
    }
}