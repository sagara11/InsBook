using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsBook.Common
{
    // Các hàm phụ ddc thêm them vào đây trong quá trình nảy sinh khi viết code
    public class Accessories
    {
        // random string
        public string RandomString()
        {
            Random random = new Random();
            Random number = new Random();
            int length = number.Next(5, 20);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}