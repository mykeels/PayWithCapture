using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class CardPaymentMasterResponse
    {
        public string transactionIdentifier { get; set; }
        public string authorizeId { get; set; }
        public string redirecturl { get; set; }
        public string responsehtml { get; set; }
        public string cookies { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public string order_id { get; set; }
        public bool redirect { get; set; }
    }
}
