using Model.EF;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public int AddCompany(SetCompany company)
        {
            nguoidung_congty nd_ct = new nguoidung_congty();
            try
            {
                int check = GetByName(company.ten);
                if (check == -1)
                {
                    congty congty = new congty();
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

                    return nd_ct.congty_id;
                }
                else
                {
                    var id = GetByName(company.ten);
                    var congty = db.congties.SingleOrDefault(x => x.id == id);
                    congty.diadiem_id = new LocationDao().GetByName(company.diadiem);

                    nd_ct.nguoidung_id = company.userID;
                    nd_ct.congty_id = GetByName(company.ten);
                    nd_ct.chucvu = company.chucvu;
                    nd_ct.batdau = company.batdau;
                    nd_ct.ketthuc = company.ketthuc;
                    nd_ct.mota = company.mota;
                    nd_ct.baomat = company.baomat;
                    db.nguoidung_congty.Add(nd_ct);
                    db.SaveChanges();

                    return nd_ct.congty_id;
                }
            }
            catch(Exception ex)
            {
                var haha = ex.Message;
                return -1;
            }
        }
        public int EditCompany(SetCompany company, int congty_id)
        {
            int check = GetByName(company.ten);
            try
            {
                if (check == -1)
                {
                    congty congty = new congty();
                    congty.ten = company.ten;
                    congty.diadiem_id = new LocationDao().GetByName(company.diadiem);
                    db.congties.Add(congty);
                    db.SaveChanges();

                    nguoidung_congty nd_ct = new nguoidung_congty();
                    nd_ct.nguoidung_id = company.userID;
                    nd_ct.congty_id = GetByName(company.ten);
                    nd_ct.chucvu = company.chucvu;
                    nd_ct.batdau = company.batdau;
                    nd_ct.ketthuc = company.ketthuc;
                    nd_ct.mota = company.mota;
                    nd_ct.baomat = company.baomat;
                    db.nguoidung_congty.Add(nd_ct);

                    var ndct = db.nguoidung_congty.SingleOrDefault(x => x.congty_id == congty_id && x.nguoidung_id==company.userID);
                    db.nguoidung_congty.Remove(ndct);

                    db.SaveChanges();

                    return GetByName(company.ten);
                }
                else
                {
                    var id = GetByName(company.ten);
                    var congty = db.congties.SingleOrDefault(x => x.id == id);
                    congty.diadiem_id = new LocationDao().GetByName(company.diadiem);

                    var nd_ct = new nguoidung_congty();
                    nd_ct.congty_id = id;
                    nd_ct.nguoidung_id = company.userID;
                    nd_ct.chucvu = company.chucvu;
                    nd_ct.batdau = company.batdau;
                    nd_ct.ketthuc = company.ketthuc;
                    nd_ct.mota = company.mota;
                    nd_ct.baomat = company.baomat;
                    db.nguoidung_congty.Add(nd_ct);

                    var ndct = db.nguoidung_congty.SingleOrDefault(x => x.congty_id == congty_id && x.nguoidung_id == company.userID);
                    db.nguoidung_congty.Remove(ndct);

                    db.SaveChanges();
                    return GetByName(company.ten);
                }
            }
            catch (Exception ex)
            {
                var haha = ex.Message;
                return -1;
            }
        }
        public bool DeleteCompany(int congty_id, int nguoidung_id)
        {
            try
            {
                var nd_ct = db.nguoidung_congty.SingleOrDefault(x => x.congty_id == congty_id && x.nguoidung_id == nguoidung_id);
                db.nguoidung_congty.Remove(nd_ct);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int GetByName(string name)
        {
            var congty = db.congties.SingleOrDefault(x => x.ten == name);
            if(congty == null)
            {
                return -1;
            } else
            {

                return congty.id;
            }
        }

        public profile_congty GetById(int congty_id, int userId)
        {
            var companies = db.Database.SqlQuery<profile_congty>("Profile_congty @id", new SqlParameter("@id", userId)).ToList();
            return companies.Find(x => x.congty_id == congty_id);
        }

        public List<string> GetAllName()
        {
            return db.Database.SqlQuery<string>("select congty.ten from congty").ToList();
        }
    }
}
