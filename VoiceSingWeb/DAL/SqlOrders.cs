using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlOrders:IOrders
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Orders> GetOrders()
        {
            var orders = db.Orders.ToList();
            return orders;
        }
        public Orders GetOrderById(int id)
        {
            var order = db.Orders.Where(o => o.orderid == id).SingleOrDefault();
            return order;
        }
        public List<Orders> GetOrdersJson()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var orders = db.Orders.ToList();
            return orders;
        }
        public IEnumerable<Orders> GetOrders1(int userid)
        {
            var MyOrder = db.Orders.Where(o => o.userid == userid);
            return MyOrder;
        }
    }
}
