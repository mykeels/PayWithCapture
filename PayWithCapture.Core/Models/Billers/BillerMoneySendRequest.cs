using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class BillerMoneySendRequest
    {
        public string product_id { get; set; }
        public string hookdata { get; set; }
        public string description { get; set; }
        public string transaction_id { get; set; }

        public class HookData
        {
            public string amount { get; set; }
            public string recipient_phone_number { get; set; }
        }
    }
}
