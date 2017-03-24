using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class EmailPaymentRequest
    {
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string amount { get; set; }
        public string merchant_id { get; set; }
        public string description { get; set; }
        public string debitaccountnumber { get; set; }
        public string transaction_id { get; set; }
    }
}
