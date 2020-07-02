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
    public class OrderdetailsManager
    {
        IOrderdetails iorderdetails = DataAccess.CreateOrderdetails();
        public IEnumerable<Orderdetails> GetOrderdetailsByOrderId(int orderid)
        {
            var orderdetails = iorderdetails.GetOrderdetailsByOrderId(orderid);
            return orderdetails;
        }

        public IEnumerable<Orderdetails> GetOrderdetails(int detailId)
        {
            var order_product = iorderdetails.GetOrderdetails(detailId);
            return order_product;

        }
    }
}
