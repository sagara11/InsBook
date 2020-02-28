using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsBook
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string Email { get; set; }
    }
    public class ForgetPass
    {
        public string Email { get; set; }
    }
}