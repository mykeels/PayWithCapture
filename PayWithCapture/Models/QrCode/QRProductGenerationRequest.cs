using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class QRProductGenerationRequest
    {
        public string merchant_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string amount_locked { get; set; }
        public string amount { get; set; }
        public string image { get; set; }
    }
}
