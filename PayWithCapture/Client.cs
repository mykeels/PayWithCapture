using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayWithCapture.Models;
using PayWithCapture.Helpers;
using PayWithCapture.Common;
using PayWithCapture.Extensions;
using Newtonsoft.Json;

namespace PayWithCapture
{
    public class Client
    {
        private Config _config { get; set; }
        private AuthenticationResponse _tokenInfo { get; set; }
        public Client(string clientId, string clientSecret, string merchantId, Common.Environment environment = Common.Environment.Staging)
        {
            this._config = new Config()
            {
                merchantId = merchantId,
                authentication = new AuthenticationRequest()
                {
                    client_id = clientId,
                    client_secret = clientSecret
                },
                environment = environment
            };
        }

        public Client(Config config)
        {
            if (config == null) throw new Exception("Config should not be NULL abeg");
            if (config.authentication == null) throw new Exception("Authentication should not be NULL abeg");
            this._config = config;
        }

        public async Task<AuthenticationResponse> authenticate()
        {
            return this._tokenInfo = await Api.PostAsync<AuthenticationResponse>(Constants.ResolveApiUrl(Constants.OAUTH_TOKEN_URL, this._config.environment), this._config.authentication.ToUrlFormEncoding(), Constants.CONTENT_TYPE_URL_FORM);
        }

        public async Task<string> requestPayment(PaymentPageRequest request)
        {
            return await Api.PostAsync(Constants.ResolveApiUrl(Constants.CAPTURE_PAY_URL, this._config.environment), request.ToUrlFormEncoding(), Constants.CONTENT_TYPE_URL_FORM);
        }
    }
}