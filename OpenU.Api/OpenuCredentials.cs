using System;
using System.Collections.Generic;
using System.Text;

namespace OpenU.Api
{
    public class OpenuCredentials
    {
        public OpenuCredentials(string username, string password, string idNumber)
        {
            UserName = username;
            Password = password;
            IdNumber = idNumber;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdNumber { get; set; }
    }
}
