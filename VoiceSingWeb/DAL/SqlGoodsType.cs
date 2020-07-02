using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlGoodsType:IGoodsType
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();

        public IEnumerable<GoodsType> GetGoodType()
        {
            var goodtype = db.GoodsType.ToList();
            return goodtype;
        }
    }
}
