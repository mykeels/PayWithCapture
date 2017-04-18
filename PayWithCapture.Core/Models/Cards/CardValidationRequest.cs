using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class CardValidationRequest
    {
        public string type { get { return Common.Constants.CARD_VALIDATE_TYPE; } }
        public string otp { get; set; }
    }
}
