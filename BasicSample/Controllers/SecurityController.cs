using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace BasicSample.Controllers
{
    public class SecurityController : Controller
    {
        private readonly HtmlEncoder _htmlEncoder;
        private readonly JavaScriptEncoder _javaScriptEncoder;
        private readonly UrlEncoder _urlEncoder;

        public SecurityController(
            HtmlEncoder htmlEncoder,
            JavaScriptEncoder javaScriptEncoder,
            UrlEncoder urlEncoder)
        {
            _htmlEncoder = htmlEncoder;
            _javaScriptEncoder = javaScriptEncoder;
            _urlEncoder = urlEncoder;
        }

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

        [HttpGet]
        public IActionResult XSS()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XSS(string content)
        {
            var htmlContnet = _htmlEncoder.Encode(content);
            var jsContnet = _javaScriptEncoder.Encode(content);
            var urlContnet = _urlEncoder.Encode(content);

            ViewBag.html = htmlContnet;
            ViewBag.dontEncodeHtml = content;
            ViewBag.js = jsContnet;
            ViewBag.url = urlContnet;

            return View();
        }
    }
}