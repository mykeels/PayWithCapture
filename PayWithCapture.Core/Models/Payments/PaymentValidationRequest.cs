using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class PaymentValidationRequest
    {
        public string type { get { return Common.Constants.ACCOUNT_ONEOFF_TYPE; } }
        public string otp { get; set; }
    }
}
