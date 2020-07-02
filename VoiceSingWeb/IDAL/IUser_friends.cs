using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUser_friends
    {
        IEnumerable<Users> GetUserFansById(int id);
        IEnumerable<User_friends> GetUserFriendsById(int id);
    }
}
