using Chargoon.DomainModels.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chargoon.DomainModels.Models
{
    public class VerificationModel
    {
        [Required(ErrorMessage = "شماره همراه نمی تواند فاقد مقدار باشد")]
        [PhoneNumber(ErrorMessage = "ساختار شماره همراه معتبر نمی باشد")]
        public string PhoneNumber { get; set; }

        public int ActivationCode { get; set; }
    }
}
