using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IUser
    {
        Users Login(string userId, string pwd);
        string Register(string phone, string pwd);        
        IEnumerable<Users> GetUser();
        Users GetUserById(int? id);//具有循环引用
        List<Users> GetUserJson();
        Users SearchUserById(int id);//不具有循环引用
        int CloseDownUser(int id);
        int OpenUser(int id);
        string EditUser(int id,Users user);
    }
}
