using System;

namespace PayWithCapture.Models
{
    public class AccountPaymentResponse
    {
        public bool verify { get; set; }
        public string message { get; set; }
        public string order_id { get; set; }
    }
}
