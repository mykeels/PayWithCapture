using System;

namespace PayWithCapture.Models
{
    public class Response<TData>
    {
        public string status { get; set; }
        public string message { get; set; }
        public TData data { get; set; }
    }
}
