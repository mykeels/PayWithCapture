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
        public const string GRANT_TYPE = "client_credentials";
        public const string SERVER_BASE_URL_STAGING = "https://pwcstaging.herokuapp.com/";
        public const string SERVER_BASE_URL_PRODUCTION = "https://pwcstaging.herokuapp.com/";
        public const string OAUTH_TOKEN_URL = "oauth/token";
        public static Environment CurrentEnvironment { get; set; }

        public static string ResolveApiUrl(string urlSuffix)
        {
            return $"{(CurrentEnvironment == Environment.Staging ? SERVER_BASE_URL_STAGING : SERVER_BASE_URL_PRODUCTION)}{urlSuffix}";
        }
    }
}
