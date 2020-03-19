using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class GetImagesModel
    {
        public Int64 id { set; get; }
        public string anh_url { set; get; }
        public int idnguoidang { set; get; }
        public string tennguoidang { set; get; }
        public string ngaydang { set; get; }
        public int luotthich { set; get; }
        public int luotbinhluan { set; get; }
        public int luotchiase { set; get; }
        public int baomat { set; get; }
        public string noidung { set; get; }
        List<image_ganthe> ganthe { set; get; }
    }

    class image_ganthe
    {
        public string ten { set; get; }
        public int id { set; get; }
    }
}
