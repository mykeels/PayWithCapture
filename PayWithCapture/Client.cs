using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayWithCapture.Models;
using PayWithCapture.Helpers;
using PayWithCapture.Common;

namespace PayWithCapture
{
    public class Client
    {
        private AuthenticationRequest _config { get; set; }
        private AuthenticationResponse _tokenInfo { get; set; }
        public Client(string clientId, string clientSecret)
        {
            this._config = new AuthenticationRequest()
            {
                client_id = clientId,
                client_secret = clientSecret
            };
        }

        public Client(AuthenticationRequest config)
        {
            if (config == null) throw new Exception("Config should not be NULL abeg");
            this._config = config;
        }

        public async Task<AuthenticationResponse> authenticate()
        {
            return this._tokenInfo = await Api.GetAsync<AuthenticationResponse>(Constants.ResolveApiUrl(Constants.OAUTH_TOKEN_URL));
        }
    }
}