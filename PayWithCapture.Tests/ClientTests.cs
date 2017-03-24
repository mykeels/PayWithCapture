using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PayWithCapture;
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
                transaction_id = Constants.SAMPLE_TRANSACTION_ID,
                description = Constants.SAMPLE_DESCRIPTION
            });
            response.Wait();
            Console.Write(response.Result);
        }
    }
}
