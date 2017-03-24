using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class BankTransferLocalResponse
    {
        public string amount { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
    }
}
