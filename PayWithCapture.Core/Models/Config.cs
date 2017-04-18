using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class Config
    {
        public string merchantId { get; set; }
        public AuthenticationRequest authentication { get; set; }
        public Common.Environment environment { get; set; }
        public Config()
        {
            this.authentication = new AuthenticationRequest();
            this.environment = Common.Environment.Staging;
        }
    }
}
