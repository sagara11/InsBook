using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsBook.Areas.Client.Models
{
    public class RegisterModel
    {
        public string Ho { set; get; }
        public string Ten { set; get; }
        public string Email { set; get; }
        public string Matkhau { set; get; }
        public string XacnhanMatkhau { set; get; }
        public DateTime Ngaysinh { set; get; }
        public string Gioitinh { set; get; }

    }
}