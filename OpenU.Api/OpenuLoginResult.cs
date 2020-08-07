using System;
using System.Collections.Generic;
using System.Text;

namespace OpenU.Api
{
    public class OpenuLoginResult
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public LoginStatus Status { get; set; }
    }

    public enum LoginStatus
    {
        Success = 1,
        Failure = 0
    }
}
