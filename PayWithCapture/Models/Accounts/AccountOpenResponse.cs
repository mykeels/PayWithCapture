using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class AccountOpenResponse
    {
        public string reference { get; set; }
        public string user_id { get; set; }
        public string status { get; set; }
        public object response { get; set; }
    }
}
