using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using Models;
using IDAL;

namespace BLL
{
    public class UserManager
    {
        IUser iuser = DataAccess.CreateUser();
        
        public Users Login(string userId,string pwd)
        {
            var user = iuser.Login(userId, pwd);
            return user;
        } 
        public string Register(string phone,string password)
        {
            string msg = iuser.Register(phone, password);
            return msg;           
        }
        public IEnumerable<Users> GetUser()
        {
            var users = iuser.GetUser();
            return users;
        }
        public Users GetUserById(int? id)
        {
            var user = iuser.GetUserById(id);
            return user;
        }
        public List<Users> GetUserJson()
        {
            var list = iuser.GetUserJson(); 
            return list;
        }
        public Users SearchUserById(int id)
        {
            var user = iuser.SearchUserById(id);
            return user;
        }
        public List<Users> GetCloseDownUserJson()
        {
            var closeuser = iuser.GetUserJson().Where(o => o.user_state == 0).ToList();
            return closeuser;
        }
        public int CloseDownUser(int id)
        {
            return iuser.CloseDownUser(id);
        }
        public int OpenUser(int id)
        {
            return iuser.OpenUser(id);
        }
        public string EditUser(int id, Users user)
        {
            string msg = iuser.EditUser(id,user);
            return msg;
        }
    }
}
