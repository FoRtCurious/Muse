using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlOrderdetails:IOrderdetails
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Orderdetails> GetOrderdetailsByOrderId(int orderid)
        {
            var orderdetails = db.Orderdetails.Where(o => o.orderid == orderid).ToList();
            return orderdetails;
        }
        public IEnumerable<Orderdetails> GetOrderdetails(int detailId)
        {
            var order_product = db.Orderdetails.Where(o => o.orderid == detailId);
            return order_product;
        }
    }
}
