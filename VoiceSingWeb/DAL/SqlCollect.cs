using System.Collections.Generic;
using System.Linq;
using IDAL;
using Models;
using System;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class SqlCollect:ICollect
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<int> GetCollectgoodtypeid(int userid)
        {

            return db.Suggest_type.Where(o => o.userId == userid).Select(o => o.goodstypeid);
        }
        public IEnumerable<Suggest_good> GetSuggestgoods(int userid)
        {
            var suggestgood = db.Suggest_good.Where(o => o.userId == userid).OrderBy(p => Guid.NewGuid()).Take(4);
            return suggestgood;
        }

        public void Add_collect(Collect collect)
        {
            db.Collect.Add(collect);
            db.SaveChanges();
        }
        public Collect searchCollect(int userid, int goodid)
        {
            var searchcollect = db.Collect.Where(o => o.userId == userid && o.goodsid == goodid).FirstOrDefault();
            return searchcollect;
        }
        public IEnumerable<Collect> GetCollects(int userid)
        {
            var MyCollect = db.Collect.Where(o => o.userId == userid);
            return MyCollect;
        }
        public void Delect_Collect(int id)
        {
            Collect collect = db.Collect.Where(o => o.collectid == id).FirstOrDefault();
            db.Collect.Remove(collect);
            db.SaveChanges();
        }

    }
}