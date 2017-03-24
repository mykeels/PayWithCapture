using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class AuthenticationResponse
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        private long _expires_in = 0;
        public long expires_in { get
            {
                return _expires_in;
            }
            set
            {
                _expires_in = value;
                created_on = DateTime.Now;
            }
        }
        public string refresh_token { get; set; }
        public DateTime created_on { get; set; }

        public AuthenticationResponse()
        {

        }

        public bool isExpired()
        {
            return created_on.AddSeconds(expires_in) < DateTime.Now;
        }
    }
}
