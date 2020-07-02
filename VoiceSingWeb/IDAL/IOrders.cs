using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
    public interface IOrders
    {

        IEnumerable<Orders> GetOrders1(int userid);
        //找到用户所对应的订单
        IEnumerable<Orders> GetOrders();
        Orders GetOrderById(int id);
        List<Orders> GetOrdersJson();
    }
}
