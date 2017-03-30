

namespace PayWithCapture.Models.Accounts
{
    public class AccountOpenRequest
    {
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public string bvn { get; set; }
        public string gender { get; set; }
        public string dateofbirth { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string state { get; set; }
        public string religion { get; set; }
        public string branchcode { get; set; }
        public string photo { get; set; }
        public string signature { get; set; }
        public string validid { get; set; }
    }
}
