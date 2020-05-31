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
        public List<GetFriendSearch> GetFriendSearches(int userId, string search_string)
        {
            return db.Database.SqlQuery<GetFriendSearch>("User_search @userId @search_string", new SqlParameter("@userId", userId), new SqlParameter("@search_string", search_string)).ToList();
        }
    }
}
