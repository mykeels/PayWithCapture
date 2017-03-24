using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class PosPrintRequest
    {
        public string merchant_code { get; set; }
        public string reference_no { get; set; }
    }
}
