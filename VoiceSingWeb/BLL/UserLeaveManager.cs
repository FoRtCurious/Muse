using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using DALFactory;

namespace BLL
{
    public class UserLeaveManager
    {
        IUserLeave iuserleave = DataAccess.CreateUserLeave();
        public IEnumerable<UserLeave> GetUserLeaveById(int userid)
        {
            var userleave = iuserleave.GetUserLeaveById(userid);
            return userleave;
        }
    }
}
