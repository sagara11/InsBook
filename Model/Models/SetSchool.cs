using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class SetSchool
    {
        public int userID { set; get; }
        public string ten { set; get; }
        public string chuyennganh { set; get; }
        public string mota { set; get; }
        public DateTime batdau { set; get; }
        public Nullable<DateTime> ketthuc { set; get; }
        public int baomat { set; get; }
        public int loaitruong { set; get; }
    }
}
