using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
    public class OrdersManager
    {
        IOrders iorders = DataAccess.CreateOrders();
        public IEnumerable<Orders> GetOrders()
        {
            var order = iorders.GetOrders();
            return order;
        }
        public Orders GetOrderById(int id)
        {
            var order = iorders.GetOrderById(id);
            return order;
        }
        public List<Orders> GetOrdersJson()
        {
            var order = iorders.GetOrdersJson();
            return order;
        }

        public IEnumerable<Orders> GetOrders1(int userid)
        {
            var MyOrder = iorders.GetOrders1(userid);
            return MyOrder;
        }
    }
}
