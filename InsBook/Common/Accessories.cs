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

            int length = number.Next(10, 20);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomNumber() // Random số có cùng độ dài
        {
            Random random = new Random();

            int length = 10;
            const string chars = "0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public UInt64 GetTime()
        {
            var utc0 = new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc); // thời gian mốc
            var issueTime = DateTime.Now; // thời gian hiện tại

            // lấy thời gian hiện tại trừ thời gian mốc -> đổi ra giây
            var iat = (UInt64)issueTime.Subtract(utc0).TotalSeconds;
            return iat;
        }
    }
}