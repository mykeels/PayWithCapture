using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class PaymentValidationResponse
    {
        public string amount { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string transactionreference { get; set; }
        public string transaction_id { get; set; }
    }
}
