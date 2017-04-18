using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Tests.Common
{
    public class Constants
    {
        public const string SAMPLE_EMAIL = "mykeels@mailinator.com";
        public const string SAMPLE_PHONE = "+2348088512130"; //must begin with +234
        public const string SAMPLE_TRANSACTION_ID = "773649uryy";
        public const string SAMPLE_DESCRIPTION = "Payment for a Goat";
        public const string SAMPLE_ACCOUNT_TYPE = "account";
        public const string ONE_OFF_ACCOUNT = "oneOffAccount";
        public const string SAMPLE_ACCOUNT = "0690000032";
        public const string SAMPLE_AMOUNT = "1000";
        public const string SAMPLE_OTP = "12346";
        public const string SAMPLE_IMAGE_URL = "data/images/storm-trooper-clone.jpg";
        public const string SAMPLE_PRODUCT_ID = "58d668d8f800fa10000af3c5";
        public const string SAMPLE_PRODUCT_NAME = "Storm-Troopers";
        public const string SAMPLE_BANK_CODE = "044";
        public const string REDIRECT_URL = "google.com.ng";

        public const string SAMPLE_CARD_NO = "5399890906267588";
        public const string SAMPLE_CVV = "222";
        public const string SAMPLE_PIN = "1234";
        public static DateTime SAMPLE_EXPIRY_DATE { get { return DateTime.Now.AddYears(2); } }
    }
}
