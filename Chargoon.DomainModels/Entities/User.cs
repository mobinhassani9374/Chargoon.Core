using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.DomainModels.Entities
{
    public class User : BaseEntity
    {
        public string PhoneNumber { get; set; }

        public int ActivationCode { get; set; }

        public DateTime CreateActivationCodeDate { get; set; }

        public string SerialNumber { get; set; }

        public string FullName { get; set; }
    }
}
