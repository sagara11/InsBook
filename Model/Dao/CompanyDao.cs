using Model.EF;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CompanyDao
    {
        InsBookDbContext db = null;
        public CompanyDao()
        {
            db = new InsBookDbContext();
        }
        public bool AddCompany(SetCompany company)
        {
            congty congty = new congty();
            nguoidung_congty nd_ct = new nguoidung_congty();

            congty.ten = company.ten;
            congty.diadiem_id = new LocationDao().GetByName(company.diadiem);
            db.congties.Add(congty);
            db.SaveChanges();


            nd_ct.nguoidung_id = company.userID;
            nd_ct.congty_id = GetByName(company.ten);
            nd_ct.chucvu = company.chucvu;
            nd_ct.batdau = company.batdau;
            nd_ct.ketthuc = company.ketthuc;
            nd_ct.mota = company.mota;
            nd_ct.baomat = company.baomat;
            db.nguoidung_congty.Add(nd_ct);
            db.SaveChanges();

            return true;
        }
        public int GetByName(string name)
        {
            var congty = db.congties.SingleOrDefault(x => x.ten == name);
            return congty.id;
        }
    }
}
