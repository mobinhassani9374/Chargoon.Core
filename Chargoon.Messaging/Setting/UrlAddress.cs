using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.Messaging.Setting
{
    public static class UrlAddress
    {
        public const string BaseUrl = "https://api.sms.ir/users/v1/";
        public const string GetTokenAddress = "Token/GetToken";
        public const string SearchContacts = "Contacts/SearchContacts?";
        public const string SendByMobileNumber = "Message/SendByMobileNumbers";
        public const string AddContacts = "Contacts/AddContacts";
    }
}
