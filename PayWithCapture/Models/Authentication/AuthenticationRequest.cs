using System;
using PayWithCapture.Common;

namespace PayWithCapture.Models
{
    public class AuthenticationRequest
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type
        {
            get
            {
                return Constants.GRANT_TYPE;
            }
        }
    }
}
