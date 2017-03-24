using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class BillerResponse: List<Biller>
    {
        
    }
    public class Biller
    {
        public string id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
}
