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
        public long expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}
