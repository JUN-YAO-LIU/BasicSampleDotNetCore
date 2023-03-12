using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class HttpAttributeController : Controller
    {
        private readonly ILogger<HttpAttributeController> _logger;

        public HttpAttributeController(ILogger<HttpAttributeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Fun1(int? id)
        {
            return Content("Http Attribute Fun1 + " + id.ToString()!);
        }

        public IActionResult Fun2(int? id)
        {
            return Content("Http Attribute Fun2 + " + id!.ToString()!);
        }
    }
}