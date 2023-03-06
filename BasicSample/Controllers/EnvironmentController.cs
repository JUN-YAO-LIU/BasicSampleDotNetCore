using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class EnvironmentController : Controller
    {
        public IActionResult Dev()
        {
            return View();
        }

        public IActionResult Prod()
        {
            return View();
        }
    }
}