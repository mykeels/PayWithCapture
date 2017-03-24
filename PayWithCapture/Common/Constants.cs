using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Common
{
    public class Constants
    {
        public const string CONTENT_TYPE_XML = "text/xml";
        public const string CONTENT_TYPE_JSON = "application/json";
        public const string CONTENT_TYPE_URL_FORM = "application/x-www-form-urlencoded";
        public const string GRANT_TYPE = "client_credentials";
        public const string SERVER_BASE_URL_STAGING = "https://pwcstaging.herokuapp.com/";
        public const string SERVER_BASE_URL_PRODUCTION = "https://pwchostedstaging.herokuapp.com/";
        public const string OAUTH_TOKEN_URL = "oauth/token";
        public const string CAPTURE_PAY_URL = "capture/pay";

        public static string ResolveApiUrl(string urlSuffix, Environment environment = Environment.Staging)
        {
            return $"{(environment == Environment.Staging ? SERVER_BASE_URL_STAGING : SERVER_BASE_URL_PRODUCTION)}{urlSuffix}";
        }
    }
}
