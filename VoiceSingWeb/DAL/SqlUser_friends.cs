using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlUser_friends:IUser_friends
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Users> GetUserFansById(int id)
        {
            var fans = (from c in db.Users join f in db.User_friends on c.userId equals f.userId where f.adduserId == id select c).ToList();
            return fans;
        }
        public IEnumerable<User_friends> GetUserFriendsById(int id)
        {
            var friends = db.User_friends.Where(o => o.userId == id).ToList();
            return friends;
        }
    }
}
