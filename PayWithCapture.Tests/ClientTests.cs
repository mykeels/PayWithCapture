using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PayWithCapture;
using System.Drawing;
using System.Configuration;
using PayWithCapture.Tests.Common;

namespace PayWithCapture.Tests
{
    [TestClass]
    public class ClientTests
    {
        string clientId = ConfigurationManager.AppSettings["pwcClientId"];
        string clientSecret = ConfigurationManager.AppSettings["pwcClientSecret"];
        string merchantId = ConfigurationManager.AppSettings["pwcMerchantId"];
        string transactionId = PayWithCapture.Common.Constants.GetTransactionId();

        private Client getDefaultClient(PayWithCapture.Common.Environment environment = PayWithCapture.Common.Environment.Staging)
        {
            return new Client(new Models.Config()
            {
                authentication = new Models.AuthenticationRequest()
                {
                    client_id = clientId,
                    client_secret = clientSecret,
                },
                merchantId = merchantId,
                environment = environment
            });
        }

        private Bitmap getImage(string filePath)
        {
            return (Bitmap)Bitmap.FromFile(filePath);
        }

        private string getBase64(Bitmap bmp)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] imageBytes = stream.ToArray();
            return Convert.ToBase64String(imageBytes);
        }

        [TestMethod]
        public void Test_That_Transaction_IDs_Are_Unique()
        {
            List<string> ret = Enumerable.Repeat<Func<string>>(() => PayWithCapture.Common.Constants.GetTransactionId(), 5).Select(fn => fn()).ToList();
            Console.WriteLine(JsonConvert.SerializeObject(ret, Formatting.Indented));
            CollectionAssert.AllItemsAreUnique(ret);
        }

        [TestMethod]
        public void Test_That_Authenticate_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.authenticate();
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_RequestPayment_Works()
        {
            Client client = this.getDefaultClient(PayWithCapture.Common.Environment.Production);
            var response = client.requestPayment(new Models.PaymentPageRequest()
            {
                merchant_id = merchantId,
                amount = Constants.SAMPLE_AMOUNT,
                customer_email = Constants.SAMPLE_EMAIL,
                customer_phone = Constants.SAMPLE_PHONE,
                redirect_url = Constants.REDIRECT_URL,
                transaction_id = transactionId,
                description = Constants.SAMPLE_DESCRIPTION
            });
            response.Wait();
            Console.Write(response.Result);
        }

        [TestMethod]
        public void Test_That_Transaction_Query_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.getTransaction(transactionId);
            response.Wait();
            Console.Write(response.Result);
        }

        [TestMethod]
        public void Test_That_Create_Payment_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.createPayment(new Models.AccountPaymentRequest()
            {
                accountnumber = Constants.SAMPLE_ACCOUNT,
                amount = Constants.SAMPLE_AMOUNT,
                description = Constants.SAMPLE_DESCRIPTION,
                hasaccessbanktoken = true,
                merchant_id = merchantId,
                transaction_id = transactionId
            });
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Validate_Payment_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.validatePayment(new Models.PaymentValidationRequest()
            {
                otp = Constants.SAMPLE_OTP
            });
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Create_Card_Payment_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.createCardPayment(new Models.CardPaymentRequest()
            {
                amount = Constants.SAMPLE_AMOUNT,
                merchant_id = merchantId,
                description = Constants.SAMPLE_DESCRIPTION,
                transaction_id = "773649urxa",
                cardno = Constants.SAMPLE_CARD_NO,
                expyear = Constants.SAMPLE_EXPIRY_DATE.Year.ToString(),
                expmth = Constants.SAMPLE_EXPIRY_DATE.Month.ToString(),
                cvv = Constants.SAMPLE_CVV,
                pin = Constants.SAMPLE_PIN,
                redirect_url = Constants.REDIRECT_URL
            });
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Validate_Card_Payment_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.validateCardPayment(new Models.CardValidationRequest()
            {
                otp = Constants.SAMPLE_OTP
            });
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Send_Sms_Otp_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.sendSmsOtp(Constants.SAMPLE_PHONE);
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Send_Voice_Otp_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.sendVoiceOtp(Constants.SAMPLE_PHONE);
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Authenticate_Otp_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.authenticateOtp(new Models.OtpAuthenticationRequest()
            {
                otp = Constants.SAMPLE_OTP,
                phonenumber = Constants.SAMPLE_PHONE
            });
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Generate_Product_QR_Works()
        {
            Client client = this.getDefaultClient();
            string productName = "Storm-Troopers";
            var response = client.generateProductQrCode(new Models.QRProductGenerationRequest()
            {
                amount = Constants.SAMPLE_AMOUNT,
                amount_locked = "true",
                description = Constants.SAMPLE_DESCRIPTION,
                image = getBase64(getImage(Constants.SAMPLE_IMAGE_URL)),
                merchant_id = merchantId,
                name = productName
            });
            response.Wait();
            System.IO.File.WriteAllText("Data/Product-" + productName + ".json", JsonConvert.SerializeObject(response.Result, Formatting.Indented));
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Fetch_Product_QR_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.fetchProductQrCode(Constants.SAMPLE_PRODUCT_ID);
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }

        [TestMethod]
        public void Test_That_Make_Account_Enquiry_Works()
        {
            Client client = this.getDefaultClient();
            var response = client.makeAccountEnquiry(new Models.AccountEnquiry()
            {
                bankcode = Constants.SAMPLE_BANK_CODE,
                accountnumber = Constants.SAMPLE_ACCOUNT
            });
            response.Wait();
            Console.Write(JsonConvert.SerializeObject(response.Result));
        }
    }
}
