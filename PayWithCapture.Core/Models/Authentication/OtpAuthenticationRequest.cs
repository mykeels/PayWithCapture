﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayWithCapture.Models
{
    public class OtpAuthenticationRequest
    {
        public string otp { get; set; }
        public string phonenumber { get; set; }
    }
}
