using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.Messaging.Models
{
    public class SendByMobileNumberResultModel : Response
    {
        public int MessageId { get; set; }
        public string BatchKey { get; set; }
        public List<SendByMobileNumberIdResultModel> Ids { get; set; }
    }
    public class SendByMobileNumberIdResultModel
    {
        public int ID { get; set; }
        public string MobileNumber { get; set; }
    }
}
