using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chargoon.DomainModels.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "شماره همراه نمی تواند فاقد مقار باشد")]
        public string PhoneNumber { get; set; }
    }
}
