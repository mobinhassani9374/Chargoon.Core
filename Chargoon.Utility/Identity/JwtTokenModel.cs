using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.Utility.Identity
{
    public class JwtTokenModel
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
