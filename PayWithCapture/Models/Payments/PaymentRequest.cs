using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class PaymentPageRequest
    {
        public string merchant_id { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
        public string redirect_url { get; set; }
        public string transaction_id { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
    }
}
