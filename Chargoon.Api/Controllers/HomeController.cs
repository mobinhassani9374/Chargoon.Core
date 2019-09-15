using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chargoon.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace Chargoon.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmsService _smsService;
        public HomeController(SmsService smsService)
        {
            _smsService = smsService;

        }
        public async Task<IActionResult> Index()
        {
            await _smsService.SendAsync(new List<string> { "09197442364" }, "mobin");
            return View();
        }
    }
}