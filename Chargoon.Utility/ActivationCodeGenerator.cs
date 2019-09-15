using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.Utility
{
    public static class ActivationCodeGenerator
    {
        public static int Generate()
        {
            return new Random().Next(1000, 9999);
        }
    }
}
