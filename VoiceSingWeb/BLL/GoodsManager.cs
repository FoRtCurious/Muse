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
    public class GoodsManager
    {
        IGoods igood = DataAccess.CreateGoods();

        public IEnumerable<Goods> GetGoods()
        {
            var goods = igood.GetGoods();
            return goods;
        }
        public Goods Getgooddetails(int id)
        {
            var good = igood.GetGoodDetails(id);
            return good;
        }      
        public IEnumerable<Goods> GetGoodslist(int? ID, int? low, int? high, string method, string search)
        {
            var list = igood.GetGoodslist(ID, low, high, method, search);
            return list;
        }
        public string AddGood(Goods good)
        {
            return igood.AddGood(good);
        }
        public string UpdateGood(int id, Goods good)
        {
            return igood.UpdateGood(id, good);
        }
        public IEnumerable<Goods> GetGoodsBytype(int goodstypeid, int num)
        {
            var Collectgood = igood.GetGoodsBytype(goodstypeid, num);

            return Collectgood;
        }


        //public IEnumerable<int> GetCollectgoodtypeid(int userid)
        //{
        //    return igood.GetCollectgoodtypeid(userid);
        //}       
        //public IEnumerable<Suggest_good> GetSuggestgoods(int userid)
        //{
        //    var suggestgood = igood.GetSuggestgoods(userid);
        //    return suggestgood;
        //}
      
       
    }
}
