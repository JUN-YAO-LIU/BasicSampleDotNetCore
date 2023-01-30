using BasicSample.Models;
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

        [HttpGet]
        public IActionResult HtmlHelper()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HtmlHelper(CreateOrder obj)
        {
            // 會吃物件的設定，如果允許null 請給問號
            // 沒有問號就是Require
            if (ModelState.IsValid)
            {
                return View(obj);
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult TagHelper()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TagHelper(CreateOrder obj)
        {
            return View();
        }
    }
}