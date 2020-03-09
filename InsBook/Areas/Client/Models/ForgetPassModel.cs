using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsBook.Areas.Client.Models
{
    public class ForgetPassModel
    {
        [Key]
        [Required(ErrorMessage = "Mời nhập email")]
        public string Email { set; get; }
        public string Pass { set; get; }
        public string CheckPass { set; get; }

    }
}