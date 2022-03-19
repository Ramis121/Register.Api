using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Register.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger 
                ?? throw new ArgumentException(nameof(logger));
        }

        public IActionResult Index()
        {
            return Ok();
        }

        //[HttpPost("register")]
        //public IActionResult Register(RegisterService registerModel)
        //{
        //    if (registerModel.Add_User(context))
        //    {
        //        return Ok($"Пользователь {registerModel.name_r} зарегался");
        //    }
        //    ModelState.AddModelError("Phone", "Некорректные Номер и(или) ник");

        //    if (!ModelState.IsValid) 
        //        return BadRequest(ModelState);

        //    return NotFound();
        //}
    }
}
