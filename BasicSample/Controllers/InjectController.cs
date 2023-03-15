using BasicSample.Application;
using BasicSample.DbAccess.Models;
using BasicSample.Models;
using BasicSample.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace BasicSample.Controllers
{
    public class InjectController : Controller
    {
        private readonly IWebHostEnvironment _env;

        private readonly ILogger<InjectController> _logger;

        private readonly TestJsonOption _setting;

        private readonly ICarService _car;

        /// <summary>
        /// Initializes a new instance of the <see cref="InjectController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="options">The options.</param>
        public InjectController(
            ILogger<InjectController> logger,
            IOptions<TestJsonOption> options,
            ICarService car,
            IWebHostEnvironment env)
        {
            _logger = logger;
            _setting = options.Value;
            _car = car;
            _env = env;
        }

        public IActionResult Test_Car_Inject()
        {
            return Content(_car.FillingUp());
        }

        public void Test_log_Inject()
        {
            _logger.LogInformation("測試 Log Inject");
        }

        public IActionResult Test_Option_Inject()
        {
            return Content("Test_Option_Inject , Name :" + _setting.name);
        }

        public IActionResult Test_Env_Inject()
        {
            return Content("Test_Env_Inject:" + _env.EnvironmentName);
        }
    }
}