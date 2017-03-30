

namespace PayWithCapture.Models
{
    public class AccountOpenValidationResponse
    {
        public string reference { get; set; }
        public string user_id { get; set; }
        public string status { get; set; }
        public string response { get; set; }
        public string brandcode { get; set; }
        public string accountnumber { get; set; }
        public string customerid { get; set; }
    }
}
