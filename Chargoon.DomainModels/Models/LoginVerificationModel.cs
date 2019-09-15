using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chargoon.DomainModels.Models
{
    public class LoginVerificationModel
    {
        [Required(ErrorMessage = "شماره همراه نمی تواند فاقد مقدار باشد")]
        public string PhoneNumber { get; set; }

        public int ActivationCode { get; set; }
    }
}
