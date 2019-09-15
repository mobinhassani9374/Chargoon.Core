using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chargoon.DomainModels.Dto;
using Chargoon.DomainModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chargoon.Core.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [HttpPost("[action]")]
        public IActionResult Login(LoginModel loginModel)
        {
            return View();
        }
    }
}