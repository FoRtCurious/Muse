using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlUserSingerApply:IUserSingerApply
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public List<UserSingerApply> GetUserSingerApply()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var applys = db.UserSingerApply.ToList();
            return applys;
        }
        public IEnumerable<UserSingerApply> GetSingerApplyByUserId(int id)
        {
            var apply = db.UserSingerApply.Where(o => o.userId == id).ToList();
            return apply;
        }
        public int AddSingerApply(UserSingerApply apply)
        {
            db.UserSingerApply.Add(apply);
            if (db.SaveChanges() > 0)
            {
                return 1;
            }
            else
                return 0;
        }
        public int AgreeApply(int id)
        {
            var user = db.Users.Find(id);
            user.userType_id = 2;
            if (db.SaveChanges() > 0)
            {
                return 1;
            }
            else
                return 0;
        }
        public int DealResult(int id)
        {
            var apply = db.UserSingerApply.Find(id);
            apply.deal_state = 1;
            if (db.SaveChanges() > 0)
            {
                return 1;
            }
            else
                return 0;
        }
    }
}
