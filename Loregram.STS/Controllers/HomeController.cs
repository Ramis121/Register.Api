using Loregram.STS.Data;
using Loregram.STS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Register.Api.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Loregram.STS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger
                ?? throw new ArgumentException(nameof(logger));
            this.dbContext = dbContext
                ?? throw new ArgumentException(nameof(dbContext));
        }

        public IActionResult Index() => View();

        [HttpGet("register")]
        public IActionResult Register() => View();

        [HttpPost("register")] 
        public IActionResult Register(RegisterService registerModel) 
        {
            if (registerModel.Add_User(dbContext))
            {
                TempData["Regis"] = $"Пользователь {registerModel.name_r} зарегестрирован";
                return RedirectToAction("Register");
            }
            TempData["Error"] = "Некорректные Номер и(или) Имя";
            //ModelState.AddModelError("Phone", "Некорректные Номер и(или) ник");

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            return RedirectToAction("Register");
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
