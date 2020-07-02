using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Objects;

namespace IDAL
{
    public interface IGoods
    {
 

        IEnumerable<Goods> GetGoodsBytype(int goodstype, int num);
        //对于推荐，通过类别得到商品
        IEnumerable<Goods> GetGoods();
        //主页热门商品 
        Goods GetGoodDetails(int id);
        //商品详情
        IEnumerable<Goods> GetGoodslist(int? ID, int? low, int? high, string method, string search);
        //商品列表及搜索      
        string AddGood(Goods good);
        string UpdateGood(int id,Goods good);
    }
}
