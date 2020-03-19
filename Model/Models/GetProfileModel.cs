using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class GetProfileModel
    {
        public int id { set; get; }
        public string anhdd { set; get; }

        public string tennguoidung { set; get; }

        public Int64 soluongbaiviet { set; get; }

        public Int64 soluongtheodoi { set; get; }

        public int soluongbanbe { set; get; }

        public string bietdanh { set; get; }

        public string loitrichdan { set; get; }
        public List<profile_diadiem> diadiem { set; get; }
        public List<profile_congty> congty { set; get; }
        public List<profile_truonghoc> truonghoc { set; get; }
        public DateTime ngaybatdau { set; get; }

        public profile_moiquanhe moiquanhe { set; get; }
        public string moiquanheString { set; get; }
        public string email { set; get; }

        public string sdt { set; get; }

        public string gioitinh { set; get; }

        public string gioithieu { set; get; }
        public DateTime ngaysinh { set; get; }
    }
    public class profile_moiquanhe
    {
        public profile_moiquanhe(string moiquanheString)
        {
            string[] arr = moiquanheString.Split(' ');
            this.anh_url = arr[0];
            this.ten = arr[1];
            this.moiquanhe = arr[2];
        }
        public string anh_url { set; get; }
        public string ten { set; get; } //Lọc được tên theo trang cá nhân của ai 
        public string moiquanhe { set; get; }
    }
    public class profile_diadiem
    {
        public string tendd { set; get; }
        public string anh_url { set; get; }
        public int loaidd { set; get; }
    }
    public class profile_congty
    {
        public string tencongty { set; get; }
        public string anh_url { set; get; }
        public string chucvu { set; get; }
        public DateTime batdau { set; get; }
        public DateTime ketthuc { set; get; }
        public string tendiadiem { set; get; }
    }
    public class profile_truonghoc
    {
        public string tentruonghoc { set; get; }
        public string anh_url { set; get; }
        public int loaitruong { set; get; }
        public DateTime batdau { set; get; }
        public DateTime ketthuc { set; get; }
        public string tendiadiem { set; get; }
        public string chuyennganh { set; get; }
        public bool totnghiep { set; get; }
    }
}
