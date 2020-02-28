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
    }
}