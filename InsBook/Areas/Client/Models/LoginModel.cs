using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsBook.Areas.Client.Models
{
    public class LoginModel
    {
        public string EmailLogin { set; get; }
        public string EmailForgetPass { set; get; }
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}