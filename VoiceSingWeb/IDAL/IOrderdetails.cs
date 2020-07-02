using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IOrderdetails
    {
        IEnumerable<Orderdetails> GetOrderdetailsByOrderId(int orderid);

        IEnumerable<Orderdetails> GetOrderdetails(int detailId);
        //展示对应订单的订单详情,评价
    }
}
