using System;

namespace PayWithCapture.Models
{
    public class AccountPaymentRequest
    {
        public string type { get; set; }
        public string amount { get; set; }
        public string merchant_id { get; set; }
        public string description { get; set; }
        public string accountnumber { get; set; }
        public bool hasaccessbanktoken { get; set; }
        public string transaction_id { get; set; }
    }
}
