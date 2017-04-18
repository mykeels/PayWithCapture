using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class BankTransferLocalRequest
    {
        public string amount { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string transferType { get; set; }
        public string bankcode { get; set; }
        public string Creditacctno { get; set; }
        public string Transaction_id { get; set; }
    }
}
