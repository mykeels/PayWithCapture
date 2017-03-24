using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class BillerProductResponse : List<BillerProduct>
    {

    }

    public class BillerProduct
    {
        public string merchant_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string cost { get; set; }
        public bool isFixedCost { get; set; }
        public string hookurl { get; set; }
        public string hookdata { get; set; }
        public string productcode { get; set; }
        public string validationurl { get; set; }
        public string ticket { get; set; }
        public decimal commission { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string owner { get; set; }
        public string id { get; set; }

        public class HookData
        {
            public string smart_card_number { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
        }
    }
}
