using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    class SqlUserLeave:IUserLeave
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<UserLeave> GetUserLeaveById(int id)
        {
            var userleave = db.UserLeave.Where(o => o.user_id == id).ToList();
            return userleave;
        }
    }
}
