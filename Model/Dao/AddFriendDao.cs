using Model.EF; 
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Model.Dao
{
    public class AddFriendDao
    {
        InsBookDbContext db = null;

        public AddFriendDao()
        {
            db = new InsBookDbContext();
        }
        public bool InsertFriend(banbe friend)
        {
            try{
                db.banbes.Add(friend);
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public List<AddFriendModel> ListAddFriend(nguoidung user)
        {
            // IdAddress = user.nguoidung_diadiem; chua lam duoc
            // IdBuddy = user... chua lam duoc
            // IdSchoolmate = ... chua lam duoc
            // IdComrade = ... chua lam duoc
            List<int> IdGender = Gender(user.gioitinh, user.id);
            List<int> IdBirthDay = Birthday(user.ngaysinh, user.id);
            
            object[] sqlParam1 =
                {
                    new SqlParameter("@idGender", String.Join("),(", IdGender.ToArray())),
                    new SqlParameter("@idBirthDay", String.Join("),(", IdBirthDay.ToArray()))
                };

            List<int> ID = db.Database.SqlQuery<int>("MergeID @idGender, @idBirthDay", sqlParam1).ToList();

            List<AddFriendModel> users = new List<AddFriendModel>();
            foreach (int Id in ID)
            {
                object[] sqlParam2 =
                {
                    new SqlParameter("@id", Id)
                };
                users.Add(db.Database.SqlQuery<AddFriendModel>("ListAddFriend @id", sqlParam2).Single());
            }
            //mới làm ưu tiên theo độ trùng. về sau làm ưu tiên độ trùng + THỨ TỰ ƯU TIÊN

            // trả lại danh sách nguoidung
            return users;
        }

        // thứ tự ưu tiên : địa điểm -> chung bạn bè -> chung trường -> chung sở thích -> giới tính -> ngày sinh

        // -- Tìm những người có chung địa điểm (càng gần ...)
        //public Address()
        //{
        //    // trả lại id 
        //}

        //// -- có chung bạn bè (càng nhiều bạn thi độ ưu tiên lên càng cao)
        //public Buddy()
        //{
        //    //trả về id
        //}

        //// -- chung trường, công ty
        //public Schoolmate()
        //{
        //    // trả về id
        //}

        //// -- chung sở thích (dựa trên những thứ đã like, chia sẻ, lưu về m)
        //public Comrade()
        //{
        //    // trả về id
        //}

        // -- phụ thuoc vao gioi tinh (Nam thì ưu tiên nữ, Nữ thì ưu tiên nam)
        public List<int> Gender(string search, int id)
        {
            string temp = (search == "Nam" ? "Nữ" : "Nam");

            object[] sqlParams =
            {
                new SqlParameter("@id", id),
                new SqlParameter("@gioitinh", temp)
            };
            return db.Database.SqlQuery<int>("Gender @id, @gioitinh", sqlParams).ToList();
        }

        // -- phụ thuộc ngày tháng năm
        public List<int> Birthday(DateTime? search, int id)
        {
            // trả danh sách id
            object[] sqlParams =
            {
                new SqlParameter("@id", id),
                new SqlParameter("@ngaysinh", search)
            };
            return db.Database.SqlQuery<int>("Birthday @id, @ngaysinh", sqlParams).ToList();
        }
    }
}
