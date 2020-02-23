using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsBook.Areas.Client.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}