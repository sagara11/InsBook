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
        public List<post_ganthe> ganthe { set; get; }
        public int luotthich { set; get; }
        public int luotbinhluan { set; get; }
        public int luotchiase { set; get; }
        public string tennguoidang { set; get; }
        public int idnguoidang { set; get; }
        public string avatarnguoidang { set; get; }
        public post_nguoinhan nguoinhantin { set; get; } //Nhom, Trang, Su Kien
        public int uutien { set; get; }
        public List<post_anh> anh { set; get; }
        public List<post_video> video { set; get; }
        public DateTime thoigiandang { set; get; }
    }
    public class post_nguoinhan
    {
        public string tennguoinhan { set; get; }
        public int id { set; get; }
    }
    public class post_ganthe
    {
        public string ten { set; get; }
        public int id { set; get; }
    }
    public class post_anh
    {
        public string anh_url { set; get; }
        public Int64 id { set; get; }
    }
    public class post_video
    {
        public string video_url { set; get; }
        public Int64 id { set; get; }
    }

}
