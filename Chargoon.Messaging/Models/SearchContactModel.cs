using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.Messaging.Models
{
    public class SearchContactModel
    {
        public string Mobile { get; set; }
    }
    public class SearchContactResultModel : Response
    {
        public List<ContactModel> Contacts { get; set; }
    }
    public class ContactModel
    {
        public int ContactRelationId { get; set; }
        public string GroupName { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public int EmojiId { get; set; }
    }
}
