using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class LogController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/");
        }
    }
}