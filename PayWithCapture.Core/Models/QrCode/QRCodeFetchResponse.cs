using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class QRCodeFetchResponse
    {
        public string merchant_id { get; set; }
        public string product_id { get; set; }
        public string cost { get; set; }
        public string app { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string id { get; set; }
    }
}
