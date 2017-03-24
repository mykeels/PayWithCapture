using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class BankTransferForeignResponse
    {
        public string amount { get; set; }
        public string status { get; set; }
        public string serviceType { get; set; }
        public string transactionRef { get; set; }
        public string customerId { get; set; }
        public string customerEmail { get; set; }
        public string customerPhone { get; set; }
        public string channel { get; set; }
        public string description { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string unique_ref { get; set; }
        public string paymentRef { get; set; }
        public string id { get; set; }
    }
}
