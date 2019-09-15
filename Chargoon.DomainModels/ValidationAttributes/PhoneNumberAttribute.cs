using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;

namespace Chargoon.DomainModels.ValidationAttributes
{
    public class PhoneNumberAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            else
            {
                var phone = (string)value;
                return phone.IsValidIranianMobileNumber();
            }
        }
    }
}
