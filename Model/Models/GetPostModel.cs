using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class GetPostModel
    {
        public Int64 id { set; get; }
        public string noidung { set; get; }
        public string diadiem { set; get; }
        public string hinhnen_url { set; get; }
        public int baomat { set; get; }
        List<ganthe> ganthe { set; get; }
        public int luotthich { set; get; }
        public int luotbinhluan { set; get; }
        public int luotchiase { set; get; }
        public string tennguoidang { set; get; }
        public int idnguoidang { set; get; }
        public string avatarnguoidang { set; get; }
        nguoinhan nguoinhantin { set; get; } //Nhom, Trang, Su Kien
        public int uutien { set; get; }
        List<anh> anh { set; get; }
        List<video> video { set; get; }
        public string thoigiandang { set; get; }
    }
    class nguoinhan
    {
        public string ten { set; get; }
        public int id { set; get; }
    }
    class ganthe
    {
        public string ten { set; get; }
        public int id { set; get; }
    }
    class anh
    {
        public string anh_url { set; get; }
        public Int64 id { set; get; }
    }
    class video
    {
        public string video_url { set; get; }
        public Int64 id { set; get; }
    }

}
