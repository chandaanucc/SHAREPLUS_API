using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shareplus.Model
{
    public class SignInRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class SignInResponse
    { 
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
