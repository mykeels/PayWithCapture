using System;
namespace PayWithCapture.Models
{
    public class CardPaymentRequest
    {
        public string type { get; set; }
        public string amount { get; set; }
        public string merchant_id { get; set; }
        public string description { get; set; }
        public string transaction_id { get; set; }
        public string cardno { get; set; }
        public string expyear { get; set; }
        public string expmth { get; set; }
        public string cvv { get; set; }
        public string pin { get; set; }
        public string redirect_url { get; set; }
    }
}
