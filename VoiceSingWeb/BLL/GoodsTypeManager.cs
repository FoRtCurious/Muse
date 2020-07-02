using System.Collections.Generic;
using IDAL;
using Models;
using DALFactory;

namespace BLL
{
    public class GoodsTypeManager
    {
        IGoodsType igoodstype = DataAccess.CreateGoodsType();
        public IEnumerable<GoodsType> GetGoodsType()
        {
            var goodstype = igoodstype.GetGoodType();
            return goodstype;
        }
    }
}
