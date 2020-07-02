using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface ICollect
    {
        IEnumerable<Suggest_good> GetSuggestgoods(int userid);
        //查询视图
        IEnumerable<int> GetCollectgoodtypeid(int userid);
        //得到用户收藏表的id

        void Add_collect(Collect collect);
        //添加收藏商品
        Collect searchCollect(int userid, int goodid);
        //找已收藏商品
        IEnumerable<Collect> GetCollects(int userid);
        //展示用户收藏商品
        void Delect_Collect(int id);
        //移除收藏的商品
    }
}
