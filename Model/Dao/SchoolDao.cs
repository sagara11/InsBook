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
    public class SchoolDao
    {
        InsBookDbContext db = null;
        public SchoolDao()
        {
            db = new InsBookDbContext();
        }

        public int AddSchool(SetSchool school)
        {
            nguoidung_truonghoc nd_th = new nguoidung_truonghoc();
            try
            {
                int check = GetByName(school.ten);
                if (check == -1)
                {
                    truonghoc truonghoc = new truonghoc();
                    truonghoc.ten = school.ten;
                    truonghoc.loaitruong = school.loaitruong;

                    if (school.loaitruong == 3)
                    {
                        var cn_id = GetByNameCN(school.chuyennganh);
                        if (cn_id == -1)
                        {
                            chuyennganh chuyennganh = new chuyennganh();
                            chuyennganh.ten = school.chuyennganh;
                            db.chuyennganhs.Add(chuyennganh);
                            db.SaveChanges();
                            truonghoc.chuyennganhs.Add(chuyennganh);
                        }
                        else
                        {
                            var chuyenganh = db.chuyennganhs.SingleOrDefault(x => x.id == cn_id);
                            truonghoc.chuyennganhs.Add(chuyenganh);
                        }
                    }

                    db.truonghocs.Add(truonghoc);
                    db.SaveChanges();

                    var school_id = GetByName(school.ten);

                    nd_th.nguoidung_id = school.userID;
                    nd_th.truonghoc_id = school_id;
                    nd_th.batdau = school.batdau;
                    nd_th.ketthuc = school.ketthuc;
                    nd_th.mota = school.mota;
                    nd_th.baomat = school.baomat;
                    db.nguoidung_truonghoc.Add(nd_th);
                    db.SaveChanges();

                    if (school.loaitruong == 3)
                    {
                        nguoidung_truonghoc_chuyennganh nd_th_cn = new nguoidung_truonghoc_chuyennganh();

                        var temp = db.nguoidung_truonghoc.SingleOrDefault(x => x.truonghoc_id == school_id && x.nguoidung_id == school.userID);
                        nd_th_cn.nguoidung_truonghoc_id = temp.id;
                        nd_th_cn.chuyennganh_id = GetByNameCN(school.chuyennganh);
                        nd_th_cn.baomat = school.baomat;
                        db.nguoidung_truonghoc_chuyennganh.Add(nd_th_cn);
                        db.SaveChanges();
                    }
                    return school_id;
                }
                else
                {

                    var truonghoc = db.truonghocs.SingleOrDefault(x => x.id == check);
                    if (truonghoc.loaitruong == school.loaitruong)
                    {
                        if (school.loaitruong == 3)
                        {
                            var cn_id = GetByNameCN(school.chuyennganh);

                            if (cn_id == -1)
                            {
                                chuyennganh chuyennganh = new chuyennganh();
                                chuyennganh.ten = school.chuyennganh;
                                db.chuyennganhs.Add(chuyennganh);

                                truonghoc.chuyennganhs.Add(chuyennganh);
                            }
                            else
                            {
                                var chuyenganh = db.chuyennganhs.SingleOrDefault(x => x.id == cn_id);
                                truonghoc.chuyennganhs.Add(chuyenganh);
                            }

                            db.SaveChanges();
                        }

                        nd_th.nguoidung_id = school.userID;
                        nd_th.truonghoc_id = check;
                        nd_th.batdau = school.batdau;
                        nd_th.ketthuc = school.ketthuc;
                        nd_th.mota = school.mota;
                        nd_th.baomat = school.baomat;
                        db.nguoidung_truonghoc.Add(nd_th);
                        db.SaveChanges();

                        if (school.loaitruong == 3)
                        {
                            nguoidung_truonghoc_chuyennganh nd_th_cn = new nguoidung_truonghoc_chuyennganh();

                            var temp = db.nguoidung_truonghoc.SingleOrDefault(x => x.truonghoc_id == check && x.nguoidung_id == school.userID);
                            nd_th_cn.nguoidung_truonghoc_id = temp.id;
                            nd_th_cn.chuyennganh_id = GetByNameCN(school.chuyennganh);
                            nd_th_cn.baomat = school.baomat;
                            db.nguoidung_truonghoc_chuyennganh.Add(nd_th_cn);
                            db.SaveChanges();
                        }
                        return check;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                var haha = ex.Message;
                return -1;
            }
        }
        public int EditSchool(SetSchool school, int truonghoc_id)
        {
            try
            {
                int check = GetByName(school.ten);
                if (check == -1)
                {
                    truonghoc truonghoc = new truonghoc();
                    truonghoc.ten = school.ten;
                    truonghoc.loaitruong = school.loaitruong;

                    if (school.loaitruong == 3)
                    {
                        var cn_id = GetByNameCN(school.chuyennganh);
                        if (cn_id == -1)
                        {
                            chuyennganh chuyennganh = new chuyennganh();
                            chuyennganh.ten = school.chuyennganh;
                            db.chuyennganhs.Add(chuyennganh);
                            db.SaveChanges();
                            truonghoc.chuyennganhs.Add(chuyennganh);
                        }
                        else
                        {
                            var chuyenganh = db.chuyennganhs.SingleOrDefault(x => x.id == cn_id);
                            truonghoc.chuyennganhs.Add(chuyenganh);
                        }
                    }

                    db.truonghocs.Add(truonghoc);
                    db.SaveChanges();

                    var school_id = GetByName(school.ten);

                    var nd_th = db.nguoidung_truonghoc.SingleOrDefault(x => x.truonghoc_id == truonghoc_id && x.nguoidung_id == school.userID);

                    nd_th.truonghoc_id = school_id;
                    nd_th.batdau = school.batdau;
                    nd_th.ketthuc = school.ketthuc;
                    nd_th.mota = school.mota;
                    nd_th.baomat = school.baomat;

                    db.SaveChanges();

                    if (school.loaitruong == 3)
                    {
                        var ndthcn = db.nguoidung_truonghoc_chuyennganh.SingleOrDefault(x => x.nguoidung_truonghoc_id == nd_th.id);
                        db.nguoidung_truonghoc_chuyennganh.Remove(ndthcn);

                        nguoidung_truonghoc_chuyennganh nd_th_cn = new nguoidung_truonghoc_chuyennganh();

                        nd_th_cn.nguoidung_truonghoc_id = nd_th.id;
                        nd_th_cn.chuyennganh_id = GetByNameCN(school.chuyennganh);
                        nd_th_cn.baomat = school.baomat;
                        db.nguoidung_truonghoc_chuyennganh.Add(nd_th_cn);

                        db.SaveChanges();
                    }

                    return school_id;
                }
                else
                {
                    if (truonghoc_id == check)
                    {
                        if (school.loaitruong == 3)
                        {
                            var cn_id = GetByNameCN(school.chuyennganh);

                            var truonghoc = db.truonghocs.SingleOrDefault(x => x.id == check);

                            if (cn_id == -1)
                            {
                                chuyennganh chuyennganh = new chuyennganh();
                                chuyennganh.ten = school.chuyennganh;
                                db.chuyennganhs.Add(chuyennganh);

                                truonghoc.chuyennganhs.Add(chuyennganh);
                            }
                            else
                            {
                                var chuyenganh = db.chuyennganhs.SingleOrDefault(x => x.id == cn_id);
                                truonghoc.chuyennganhs.Add(chuyenganh);
                            }

                            db.SaveChanges();
                        }

                        var nd_th = db.nguoidung_truonghoc.SingleOrDefault(x => x.truonghoc_id == truonghoc_id && x.nguoidung_id == school.userID);

                        nd_th.batdau = school.batdau;
                        nd_th.ketthuc = school.ketthuc;
                        nd_th.mota = school.mota;
                        nd_th.baomat = school.baomat;

                        db.SaveChanges();

                        if (school.loaitruong == 3)
                        {
                            var ndthcn = db.nguoidung_truonghoc_chuyennganh.SingleOrDefault(x => x.nguoidung_truonghoc_id == nd_th.id);
                            db.nguoidung_truonghoc_chuyennganh.Remove(ndthcn);

                            nguoidung_truonghoc_chuyennganh nd_th_cn = new nguoidung_truonghoc_chuyennganh();

                            nd_th_cn.nguoidung_truonghoc_id = nd_th.id;
                            nd_th_cn.chuyennganh_id = GetByNameCN(school.chuyennganh);
                            nd_th_cn.baomat = school.baomat;
                            db.nguoidung_truonghoc_chuyennganh.Add(nd_th_cn);

                            db.SaveChanges();
                        }
                        return check;
                    }
                    else
                    {
                        var test = db.nguoidung_truonghoc.SingleOrDefault(x => x.truonghoc_id == check && x.nguoidung_id == school.userID);
                        if (test == null)
                        {
                            var truonghoc = db.truonghocs.SingleOrDefault(x => x.id == check);
                            if(truonghoc.loaitruong == school.loaitruong)
                            {
                                if (school.loaitruong == 3)
                                {
                                    var cn_id = GetByNameCN(school.chuyennganh);

                                    if (cn_id == -1)
                                    {
                                        chuyennganh chuyennganh = new chuyennganh();
                                        chuyennganh.ten = school.chuyennganh;
                                        db.chuyennganhs.Add(chuyennganh);

                                        truonghoc.chuyennganhs.Add(chuyennganh);
                                    }
                                    else
                                    {
                                        var chuyenganh = db.chuyennganhs.SingleOrDefault(x => x.id == cn_id);
                                        truonghoc.chuyennganhs.Add(chuyenganh);
                                    }

                                    db.SaveChanges();
                                }

                                var nd_th = db.nguoidung_truonghoc.SingleOrDefault(x => x.truonghoc_id == truonghoc_id && x.nguoidung_id == school.userID);

                                nd_th.truonghoc_id = check;
                                nd_th.batdau = school.batdau;
                                nd_th.ketthuc = school.ketthuc;
                                nd_th.mota = school.mota;
                                nd_th.baomat = school.baomat;

                                db.SaveChanges();

                                db.SaveChanges();

                                if (school.loaitruong == 3)
                                {
                                    var ndthcn = db.nguoidung_truonghoc_chuyennganh.SingleOrDefault(x => x.nguoidung_truonghoc_id == nd_th.id);
                                    db.nguoidung_truonghoc_chuyennganh.Remove(ndthcn);

                                    nguoidung_truonghoc_chuyennganh nd_th_cn = new nguoidung_truonghoc_chuyennganh();

                                    nd_th_cn.nguoidung_truonghoc_id = nd_th.id;
                                    nd_th_cn.chuyennganh_id = GetByNameCN(school.chuyennganh);
                                    nd_th_cn.baomat = school.baomat;
                                    db.nguoidung_truonghoc_chuyennganh.Add(nd_th_cn);

                                    db.SaveChanges();
                                }
                                return check;
                            }
                        }
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public bool DeleteSchool(int school_id, int nguoidung_id, int loaitruong)
        {
            try
            {
                var nd_th = db.nguoidung_truonghoc.SingleOrDefault(x => x.truonghoc_id == school_id && x.nguoidung_id == nguoidung_id);
                if (loaitruong == 3)
                {
                    var nd_th_cn = db.nguoidung_truonghoc_chuyennganh.SingleOrDefault(x => x.nguoidung_truonghoc_id == nd_th.id);

                    db.nguoidung_truonghoc_chuyennganh.Remove(nd_th_cn);
                    db.SaveChanges();
                }

                db.nguoidung_truonghoc.Remove(nd_th);
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
            var school = db.truonghocs.SingleOrDefault(x => x.ten == name);
            if (school == null)
            {
                return -1;
            }
            else
            {
                return school.id;
            }
        }
        public int GetByNameCN(string name)
        {
            var chuyennganh = db.chuyennganhs.SingleOrDefault(x => x.ten == name);
            if (chuyennganh == null)
            {
                return -1;
            }
            else
            {
                return chuyennganh.id;
            }
        }
        public List<string> GetAllName()
        {
            return db.Database.SqlQuery<string>("select truonghoc.ten from truonghoc").ToList();
        }
        public List<string> GetAllNameCN(string school_name)
        {
            return db.Database.SqlQuery<string>("GetCNBySchool @school_name", new SqlParameter("@school_name", school_name)).ToList();
        }
        public profile_truonghoc GetById(int truonghoc_id, int userId)
        {
            var schools = db.Database.SqlQuery<profile_truonghoc>("Profile_truonghoc @id", new SqlParameter("@id", userId)).ToList();
            return schools.Find(x => x.truonghoc_id == truonghoc_id);
        }
    }
}
