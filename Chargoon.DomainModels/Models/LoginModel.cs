using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Chargoon.DomainModels.ValidationAttributes;


namespace Chargoon.DomainModels.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "شماره همراه نمی تواند فاقد مقار باشد")]
        [PhoneNumber(ErrorMessage ="ساختار شماره همراه معتبر نمی باشد")]
        public string PhoneNumber { get; set; }
    }
}
