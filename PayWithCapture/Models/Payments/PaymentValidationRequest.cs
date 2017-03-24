using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class PaymentValidationRequest
    {
        public string type { get; set; }
        public string otp { get; set; }
    }
}
