using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlAccusedUsers:IAccusedUsers
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public List<AccusedUsers> GetAccusedUsers()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var accusedusers = db.AccusedUsers.ToList();
            return accusedusers;
        }
        public AccusedUsers GetAccusedById(int accusedid)
        {
            var accused = db.AccusedUsers.Find(accusedid);
            return accused;
        }
        public int DealResult(int accusedid)
        {
            var accused = db.AccusedUsers.Find(accusedid);
            accused.deal_state = 1;
            if (db.SaveChanges() > 0)
                return 1;
            else
                return 0;
        }
    }
}
