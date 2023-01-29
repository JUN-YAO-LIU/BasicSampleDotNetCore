using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class RazorController : Controller
    {
        public IActionResult Razor()
        {
            return View();
        }

        public IActionResult BasicSyntax()
        {
            return View();
        }
    }
}