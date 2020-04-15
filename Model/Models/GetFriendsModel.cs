using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class GetFriendsModel
    {
        public int id { set; get; }
        public string ho { set; get; }
        public string ten { set; get; }
        public string anh_url { set; get; }
        public string value
        {
            set
            {
                this.value = value;
            }
            get
            {
                return this.ho + " " + this.ten;
            }

        }
    }

}
