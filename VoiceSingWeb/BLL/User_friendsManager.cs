using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
    public class User_friendsManager
    {
        IUser_friends iuserfriends = DataAccess.CreateUser_friends();
        public IEnumerable<Users> GetUserFansById(int id)
        {
            var fans = iuserfriends.GetUserFansById(id);
            return fans;
        }
        public IEnumerable<User_friends> GetUserFriendsById(int id)
        {
            var friends = iuserfriends.GetUserFriendsById(id);
            return friends;
        }
    }
}
