using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Common;

namespace Model.Dao
{
    public class FriendDao
    {
        InsBookDbContext db = null;
        public FriendDao()
        {
            db = new InsBookDbContext();
        }
        public List<GetFriendSearch> GetFriendSearches(string friend_name, int user_id)
        {
            return db.Database.SqlQuery<GetFriendSearch>("User_search @friend_name, @user_id", new SqlParameter("@friend_name", friend_name), new SqlParameter("@user_id", user_id)).ToList();
        }
        public List<GetFriendSearch> GetNotFriendSearches(string friend_name, int user_id)
        {
            return db.Database.SqlQuery<GetFriendSearch>("User_search_notfriend @friend_name, @user_id", new SqlParameter("@friend_name", friend_name), new SqlParameter("@user_id", user_id)).ToList();
        }
    }
}
