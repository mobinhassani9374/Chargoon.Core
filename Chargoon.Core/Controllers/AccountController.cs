using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chargoon.DataLayer.Repositories;
using Chargoon.DomainModels.Models;
using Chargoon.Messaging;
using Chargoon.Utility;
using Chargoon.Utility.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chargoon.Core.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous()]
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly SmsService _smsService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        public AccountController(UserRepository userRepository,
            SmsService smsService,
            JwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _smsService = smsService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.FindByPhoneNumber(loginModel.PhoneNumber);

                if (user == null)
                    return Ok(ServiceResult.Error("کاربری یافت نشد"));

                else
                {
                    // generate activationCode

                    var activationCode = new Random().Next(1000, 9999);

                    var smsResponse = await _smsService
                        .SendAsync(new List<string> { user.PhoneNumber }, $"با سلام کد فعالسازی شما : {activationCode}");

                    if (smsResponse.IsSuccessful)
                    {
                        user.ActivationCode = activationCode;
                        user.CreateActivationCodeDate = DateTime.Now;

                        // update user
                        _userRepository.Update(user);

                        return Ok(ServiceResult.Okay("کد فعالسازی برای کاربر ارسال شد"));
                    }

                    else
                        return Ok(ServiceResult.Error($"خطا در ارسال پیامک از سمت پیامک سفید : {smsResponse.Message}"));
                }
            }

            return Ok(ServiceResult.Error("model is not valid"));
        }

        [HttpPost("[action]")]
        public IActionResult Verifiy([FromBody]VerificationModel verificationModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.FindByPhoneNumber(verificationModel.PhoneNumber);

                if (user == null) return Ok(ServiceResult.Error("کاربری یافت نشد"));

                else
                {
                    if (user.ActivationCode ==verificationModel.ActivationCode)
                    {
                        // check time
                        var nowDate = DateTime.Now;

                        var elabsedTime = nowDate - user.CreateActivationCodeDate;

                        if (elabsedTime.Duration().TotalSeconds > 240)
                        {
                            return Ok(ServiceResult.Error("کد فعالسازی اعتباری ندارد"));
                        }
                        else
                        {
                            var token = _jwtTokenGenerator.Generate(user);
                            return Ok(ServiceResult.Okay(token));
                        }
                    }

                    else return Ok(ServiceResult.Error("کد فعالسازی نامعتبر می باشد"));

                }
            }


            return Ok(ServiceResult.Error("model is not valid"));
        }
    }
}