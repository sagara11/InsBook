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
        public int? diadiem_id { set; get; }
        public string diadiem { set; get; } //--
        public string hinhnen_url { set; get; } //
        public int baomat { set; get; }
        public List<post_ganthe> ganthe { set; get; } //--
        public int luotthich { set; get; } //++
        public List<dsnguoithich> dsnguoithich { set; get; }
        public int luotbinhluan { set; get; } //++
        public int luotchiase { set; get; } //
        public string tennguoidang { set; get; }
        public int idnguoidang { set; get; }
        public string avatarnguoidang { set; get; }
        public post_nguoinhan nguoinhantin { set; get; } //Nhom, Trang, Su Kien //
        public int uutien { set; get; } //
        public List<post_anh> anh { set; get; } //--
        public List<post_video> video { set; get; } //
        public Int64 thoigiandang { set; get; } //
        public string viewthoigian { set; get; } //
        public List<post_comment> comment { set; get; } //++
    }
    public class dsnguoithich
    {
        public string anhnguoithich { set; get; }
        public string tennguoithich { set; get; }
        public int idnguoithich { set; get; }
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
        public string anh_url { set; get; } //url của ảnh con
        public Int64 id { set; get; } //id của bài viết con
    }
    public class post_video
    {
        public string video_url { set; get; }
        public Int64 id { set; get; }
    }
    public class post_comment
    {
        public Int64 comment_id { set; get; }
        public Int64 post_id { set; get; }
        public List<post_comment_child> comment_child { set; get; } // ++
        public int idnguoidang { set; get; }
        public string anhnguoidang { set; get; }
        public string tennguoidang { set; get; }
        public int luotthich { set; get; } // Chưa có bảng thích bình luận
        public string noidung { set; get; }
        public DateTime thoigiandang { set; get; } //
        public int luotbinhluan { set; get; } // ++
    }
    public class post_comment_child
    {
        public Int64 comment_id { set; get; }
        public Int64 post_id { set; get; }
        public int idnguoidang { set; get; }
        public string anhnguoidang { set; get; }
        public string tennguoidang { set; get; }
        public string noidung { set; get; }
        public int luotthichbinhluan { set; get; } // Chưa có bảng thích bình luận
        public DateTime thoigiandang { set; get; } //
        public Int64? parent_id { set; get; }
    }
}
