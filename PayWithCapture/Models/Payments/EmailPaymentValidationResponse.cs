using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class EmailPaymentValidationResponse
    {
        public string amount { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string transactionreference { get; set; }
        public string transaction_id { get; set; }
        public Order order { get; set; }

        public class Order
        {
            public string user_id { get; set; }
            public string merchant_id { get; set; }
            public string createdBy { get; set; }
            public string owner { get; set; }
            public string hookurl { get; set; }
            public object hookdata { get; set; }
            public string description { get; set; }
            public decimal cost { get; set; }
            public string _ref { get; set; }
            public string account_id { get; set; }
            public string recon_ref { get; set; }
            public bool paid { get; set; }
            public SettleRatio settle_ratio { get; set; }
            public object adjusted_settle_ratio { get; set; }
            public bool settled { get; set; }
            public bool delivered { get; set; }
            public bool saved { get; set; }
            public bool recurring { get; set; }
            public bool moneyRequest { get; set; }
            public bool cancel { get; set; }
            public bool isCore { get; set; }
            public string flow_status { get; set; }
            public string reverse_status { get; set; }
            public decimal reverse_retry { get; set; }
            public string paidWithForeignCard { get; set; }
            public bool noFee { get; set; }
            public string donateToCharity { get; set; }
            public bool printed { get; set; }
            public decimal user_fee { get; set; }
            public decimal merchant_fee { get; set; }
            public decimal actual_cost { get; set; }
            public string linking_ref { get; set; }
            public string createdAt { get; set; }
            public string updatedAt { get; set; }
            public string balance { get; set; }
            public string id { get; set; }

            public class SettleRatio
            {
                public object[] settle { get; set; }
            }
        }
    }
}