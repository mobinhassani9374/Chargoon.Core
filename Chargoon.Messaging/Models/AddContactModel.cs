using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.Messaging.Models
{
    public class AddContactModel
    {
        public List<ContactsDetailModel> ContactsDetails { get; set; }
        public int GroupId { get; set; }
    }
    public class ContactsDetailModel
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public int? EmojiId { get; set; }
    }
}
