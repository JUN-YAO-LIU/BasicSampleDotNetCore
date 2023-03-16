using BasicSample.DbAccess.Models;
using BasicSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasicSample.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        // 明確檢視
        public IActionResult AboutTest()
        {
            return View("About_Test");
        }

        // 強型別 - viewModel
        public IActionResult SendModel()
        {
            return View(new Car { Name = "Test", Description = "描述" });
        }

        // 明確檢視
        public IActionResult SendModelToSpecialView()
        {
            return View("SpecialViewGetModel", new Car { Name = "Test", Description = "描述" });
        }

        // 弱型別 - ViewBag
        public IActionResult TestViewBag()
        {
            return View();
        }

        // 弱型別 - ViewData
        public IActionResult TestViewData()
        {
            return View();
        }

        // 弱型別 - ViewData屬性應用
        public IActionResult TestViewDataProperty()
        {
            return View();
        }

        // 弱型別 - Tempdate
        public IActionResult TestTempDate()
        {
            TempData["TestTemp"] = "測試";
            ViewBag.Test = "ViewBag Test";
            return Ok();
        }

        public IActionResult TestTempDate_GetTempData()
        {
            var t = TempData["TestTemp"];
            var v = ViewBag.Test;
            return Ok();
        }

        public IActionResult TestPartial()
        {
            return View(new Car { Name = "Partial Car", Description = "部分檢視 車車" });
        }
    }
}