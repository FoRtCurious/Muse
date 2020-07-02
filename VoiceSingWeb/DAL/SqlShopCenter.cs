using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using System.Data.Entity;

namespace DAL
{
   public class SqlShopCenter:IShopCenter
    {
        // SingMusicDataBaseEntities1 viewModel = new SingMusicDataBaseEntities1();
         SingMusicDataBaseEntities db = new SingMusicDataBaseEntities();

        public void Add_address(Receipt_address addr)
        {
            db.Receipt_address.Add(addr);
            db.SaveChanges();
        }
        public void Update_adddress(Receipt_address addr)
        {
            db.Set<Receipt_address>().Attach(addr);
            db.Entry<Receipt_address>(addr).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delect_address(int id)
        {
            Receipt_address receiptadd = db.Receipt_address.Where(o => o.addressid == id).FirstOrDefault();
            db.Receipt_address.Remove(receiptadd);
            db.SaveChanges();
        }
        public IEnumerable<Orders> GetOrders(int userid)
         {
             var MyOrder = db.Orders.Where(o => o.userid == userid);
             return MyOrder;
         }
        public IEnumerable<Receipt_address> GetReceipt_Addresses(int userid)
         {
             var MyAddr = db.Receipt_address.Where(o => o.userid == userid);
             return MyAddr;
         }

        public IEnumerable<Orderdetails> GetOrderdetails(int detailId)
        {
            var order_product = db.Orderdetails.Where(o => o.orderid == detailId);
            return order_product;
        }

        public IEnumerable<Receipt_address> MyOrderaddress(int userid)
        {
            var orderaddress = db.Receipt_address.Where(o => o.userid == userid);
            return orderaddress;
        }

        public Receipt_address GetAddress(int addressid)
        {
            var Address = db.Receipt_address.Find(addressid);
            return Address;
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
        public IEnumerable<Collect>GetCollects(int userid)
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
