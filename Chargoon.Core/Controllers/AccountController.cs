using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chargoon.DataLayer.Repositories;
using Chargoon.DomainModels.Models;
using Chargoon.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chargoon.Core.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous()]
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;
        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("[action]")]
        public IActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                
            }

            return Ok(ServiceResult.Error());
        }
    }
}