

namespace PayWithCapture.Models
{
    public class AccountOpenValidationRequest
    {
        public string otp { get; set; }
        public string trxref { get; set; }
    }
}
