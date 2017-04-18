using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class CardPaymentVerveResponse
    {
        public string responsetoken { get; set; }
        public string responsecode { get; set; }
        public string responsemessage { get; set; }
        public string transactionreference { get; set; }
        public string otptransactionidentifier { get; set; }
        public string responsehtml { get; set; }
        public string verify { get; set; }
        public string order_id { get; set; }
    }
}
