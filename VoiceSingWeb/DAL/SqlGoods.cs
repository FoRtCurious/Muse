using System.Collections.Generic;
using System.Linq;
using IDAL;
using Models;
using System;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class SqlGoods:IGoods
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();


        public IEnumerable<Goods> GetGoods()
        {
            var products = db.Goods.ToList();
            return products;                                       
        }
        public Goods GetGoodDetails(int id)
        {
            var gooddetails = db.Goods.Find(id);
            return gooddetails;
        }
        public IEnumerable<Goods> GetGoodslist(int? ID, int? low, int? high, string method, string search)
        {
            int typeID = ID ?? 0;
            IQueryable<Goods> list;
            if (typeID == 0 && low == null && high == null)
            {
                list = db.Goods.Select(o => o);//展示所有的商品
            }
            else if (typeID != 0 && low == null && high == null)
            {
                list = db.Goods.Where(o => o.goodstypeid == ID);
            }
            else if (typeID == 0)
            {
                list = db.Goods.Where(o => o.price <= high && o.price >= low);
            }
            else
            {
                list = db.Goods.Where(o => o.goodstypeid == ID && o.price <= high && o.price >= low);
            }
            if (search != null)
            {
                list = list.Where(o => o.goodsname.Contains(search));
                //ViewBag.sum = list.Count();
            }
            if (method == "big")
            {
                list = list.OrderByDescending(o => o.price);
            }
            else if (method == "small")
            {
                list = list.OrderBy(o => o.price);
            }
            return list;
        }
        public IEnumerable<Goods> GetGoodsBytype(int goodstypeid, int num)
        {
            var Collectgood = db.Goods.Where(o => o.goodstypeid == goodstypeid).Take(num);

            return Collectgood;
        }
        public string AddGood(Goods good)
        {
            db.Goods.Add(good);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public string UpdateGood(int id, Goods good)
        {
            var goods = db.Goods.Find(id);
            goods = good;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }

    }
}
