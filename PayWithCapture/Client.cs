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
using Newtonsoft.Json.Linq;

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

        private Dictionary<string, string> getDefaultHeaders()
        {
            var ret = new Dictionary<string, string>();
            if (this.isAuthenticated()) ret.Add("Authorization", "Bearer " + _tokenInfo.access_token);
            return ret;
        }

        public bool isAuthenticated()
        {
            return _tokenInfo != null && !_tokenInfo.isExpired();
        }

        public async Task<AuthenticationResponse> authenticate()
        {
            if (!this.isAuthenticated())
                return this._tokenInfo = await Api.PostAsync<AuthenticationResponse>(Constants.ResolveApiUrl(Constants.OAUTH_TOKEN_URL, this._config.environment), this._config.authentication.ToUrlFormEncoding(), Constants.CONTENT_TYPE_URL_FORM);
            else return await Task.Run(() => _tokenInfo);
        }

        public async Task<string> requestPayment(PaymentPageRequest request)
        {
            return await Api.PostAsync(Constants.ResolveApiUrl(Constants.CAPTURE_PAY_URL, this._config.environment), request.ToUrlFormEncoding(), Constants.CONTENT_TYPE_URL_FORM, getDefaultHeaders());
        }

        public async Task<string> getTransaction(string transaction_id)
        {
            await this.authenticate();
            return await Api.PostAsync(Constants.ResolveApiUrl(Constants.TRANSACTION_DETAILS_URL, this._config.environment), (new TransactionRequest() { transaction_id = transaction_id }).ToUrlFormEncoding(), Constants.CONTENT_TYPE_URL_FORM, getDefaultHeaders());
        }

        public async Task<Response<AccountPaymentResponse>> createPayment(AccountPaymentRequest paymentRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            var ret = await Api.PostAsync<Response<AccountPaymentResponse>>(Constants.ResolveApiUrl(Constants.PAYMENT_URL, this._config.environment), paymentRequest.ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
            return ret;
        }

        public async Task<Response<PaymentValidationResponse>> validatePayment(PaymentValidationRequest paymentRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.PostAsync<Response<PaymentValidationResponse>>(Constants.ResolveApiUrl(Constants.VALIDATE_PAYMENT_URL, this._config.environment), paymentRequest.ToUrlFormEncoding(), Constants.CONTENT_TYPE_URL_FORM, getDefaultHeaders());
        }

        public async Task<Response<CardPaymentMasterResponse>> createCardPayment(CardPaymentRequest paymentRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            try
            {
                return await Api.PostAsync<Response<CardPaymentMasterResponse>>(Constants.ResolveApiUrl(Constants.CREATE_CARD_PAYMENT_URL, this._config.environment), paymentRequest.ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
            }
            catch (Exception ex)
            {
                var jObj = JObject.Parse(ex.Message);
                return new Response<CardPaymentMasterResponse>()
                {
                    status = jObj.Value<string>("status"),
                    message = jObj.Value<string>("data")
                };
            }
        }

        public async Task<Response<CardPaymentVerveResponse>> createVerveCardPayment(CardPaymentRequest paymentRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            try
            {
                return await Api.PostAsync<Response<CardPaymentVerveResponse>>(Constants.ResolveApiUrl(Constants.CREATE_CARD_PAYMENT_URL, this._config.environment), paymentRequest.ToUrlFormEncoding(), Constants.CONTENT_TYPE_URL_FORM, getDefaultHeaders());
            }
            catch (Exception ex)
            {
                var jObj = JObject.Parse(ex.Message);
                return new Response<CardPaymentVerveResponse>()
                {
                    status = jObj.Value<string>("status"),
                    message = jObj.Value<string>("data")
                };
            }
        }

        public async Task<Response<CardValidationResponse>> validateCardPayment(CardValidationRequest paymentRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            try
            {
                return await Api.PostAsync<Response<CardValidationResponse>>(Constants.ResolveApiUrl(Constants.VALIDATE_CARD_PAYMENT_URL, this._config.environment), paymentRequest.ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
            }
            catch (Exception ex)
            {
                var jObj = JObject.Parse(ex.Message);
                return new Response<CardValidationResponse>()
                {
                    status = jObj.Value<string>("status"),
                    message = jObj.Value<string>("data")
                };
            }
            
        }

        public async Task<Response<List<PosPrintResponse>>> getPayments(CardValidationRequest paymentRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.PostAsync<Response<List<PosPrintResponse>>>(Constants.ResolveApiUrl(Constants.TRANSACTION_DETAILS_URL, this._config.environment), paymentRequest.ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
        }

        public async Task<Response<string>> sendSmsOtp(string phone)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.GetAsync<Response<string>>(Constants.ResolveApiUrl(Constants.SMS_OTP_URL, this._config.environment) + "/" + phone, getDefaultHeaders());
        }

        public async Task<Response<string>> sendVoiceOtp(string phone)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.GetAsync<Response<string>>(Constants.ResolveApiUrl(Constants.VOICE_OTP_URL, this._config.environment) + "/" + phone, getDefaultHeaders());
        }

        public async Task<Response<OtpAuthenticationResponse>> authenticateOtp(OtpAuthenticationRequest otpAuthRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.PostAsync<Response<OtpAuthenticationResponse>>(Constants.ResolveApiUrl(Constants.AUTHENTICATE_OTP_URL, this._config.environment), otpAuthRequest.ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
        }

        public async Task<Response<QRProductGenerationResponse>> generateQrCode(QRProductGenerationRequest productQrRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.PostAsync<Response<QRProductGenerationResponse>>(Constants.ResolveApiUrl(Constants.QR_PRODUCT_URL, this._config.environment), productQrRequest.ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
        }

        public async Task<Response<QRProductGenerationResponse>> generateProductQrCode(QRProductGenerationRequest productQrRequest)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.PostAsync<Response<QRProductGenerationResponse>>(Constants.ResolveApiUrl(Constants.QR_PRODUCT_URL, this._config.environment), productQrRequest.ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
        }

        public async Task<Response<QRCodeFetchResponse>> fetchProductQrCode(string productId)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.PostAsync<Response<QRCodeFetchResponse>>(Constants.ResolveApiUrl(Constants.QR_PRODUCT_URL, this._config.environment), (new QRCodeFetchRequest() { product_id = productId }).ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
        }

        public async Task<string> makeAccountEnquiry(AccountEnquiry accountEnquiry)
        {
            await this.authenticate(); //important! make sure the client is authenticated
            return await Api.PostAsync(Constants.ResolveApiUrl(Constants.ACCOUNT_VALIDATE_URL, this._config.environment), accountEnquiry.ToJson(), Constants.CONTENT_TYPE_JSON, getDefaultHeaders());
        }
    }
}