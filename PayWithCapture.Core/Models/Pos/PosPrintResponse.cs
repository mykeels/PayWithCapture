using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class PosPrintResponse
    {
        public string order_id { get; set; }
        public string payment_id { get; set; }
        public decimal amount { get; set; }
        public string payment_ref { get; set; }
        public string transaction_id { get; set; }
        public string customer_firstname { get; set; }
        public string customer_lastname { get; set; }
        public string customer_phonenumber { get; set; }
        public string customer_narration { get; set; }
        public string merchant_code { get; set; }
        public string customer_ref { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string linking_ref { get; set; }
        public string recon_ref { get; set; }
        public decimal merchant_fee { get; set; }
        public string card_locale { get; set; }
        public bool printed { get; set; }
        public string payment_date { get; set; }
        public GatewayResponse gateway_response { get; set; }

        public class GatewayResponse
        {
            public string batchno { get; set; }
            public string merchtransactionreference { get; set; }
            public string orderinfo { get; set; }
            public string receiptno { get; set; }
            public string transactionno { get; set; }
            public string ResponseCode { get; set; }
            public string RespnseDescription { get; set; }
            public string transactionIdentifier { get; set; }
            public string redirecturl { get; set; }
            public string MIGS3TransactionReference { get; set; }
            public string TransactionReference { get; set; }
        }
    }
}
