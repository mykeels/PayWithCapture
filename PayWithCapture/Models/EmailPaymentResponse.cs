using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class EmailPaymentResponse
    {
        public string verify { get; set; }
        public string message { get; set; }
        public string order_id { get; set; }
    }
}
