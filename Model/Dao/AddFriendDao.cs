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
            List<int> IdGender = Gender(user.gioitinh);
            List<int> IdBirthDay = Birthday(user.ngaysinh);

            // Chưa xử lý trùng
            
            // Các câu truy vấn chỉ theo id
            List<AddFriendModel> users = new List<AddFriendModel>();
            foreach (int Id in IdGender)
            {
                object[] sqlParams =
                {
                    new SqlParameter("@id", Id)
                };
                users.Add(db.Database.SqlQuery<AddFriendModel>("ListAddFriend @id", sqlParams).Single());
            }
            // Danh sách tìm đc đang có cả chính nó
            // Danh sách tìm dc phải loại bỏ những thằng đã kb với nhau, chặn, đã gửi lời kb
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
        public List<int> Gender(string searchString)
        {
            string temp = (searchString == "Nam" ? "Nữ" : "Nam");
            
            // sử dụng LinQ (câu lệnh SQL server)
            var model = from a in db.nguoidungs
                        where a.gioitinh == temp
                        select a.id;
            
            // trả danh sách id
            return model.ToList();
        }

        // -- phụ thuộc ngày tháng năm
        public List<int> Birthday(DateTime? search)
        {
            // trả danh sách id
            object[] sqlParams =
            {
                new SqlParameter("@ngaysinh", search)
            };
            return db.Database.SqlQuery<int>("Birthday @ngaysinh", sqlParams).ToList();
        }
    }
}
