using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    class Accessories
    {
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