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
   public class CollectManager
    {
        ICollect icollect = DataAccess.CreateCollect();
        public IEnumerable<int> GetCollectgoodtypeid(int userid)
        {
            return icollect.GetCollectgoodtypeid(userid);
        }
        public IEnumerable<Suggest_good> GetSuggestgoods(int userid)
        {
            var suggestgood = icollect.GetSuggestgoods(userid);
            return suggestgood;
        }


        public void Add_collect(Collect collect)
        {
            icollect.Add_collect(collect);
        }
        public Collect searchCollect(int userid, int goodid)
        {
            var searchcollect = icollect.searchCollect(userid, goodid);
            return searchcollect;
        }
        public IEnumerable<Collect> GetCollects(int userid)
        {
            var MyCollect = icollect.GetCollects(userid);
            return MyCollect;
        }
        public void Delect_Collcet(int id)
        {
            icollect.Delect_Collect(id);
        }
    }
}
