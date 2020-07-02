using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
   public interface IShopCenter
    {
        
        IEnumerable<Orders> GetOrders(int userid);
        IEnumerable<Receipt_address> GetReceipt_Addresses(int userid);
       
        void Add_address(Receipt_address addr);
        void Delect_address(int id);
        void Update_adddress(Receipt_address addr);
        IEnumerable<Orderdetails> GetOrderdetails( int detailId);
        IEnumerable<Receipt_address> MyOrderaddress(int userid);
        Receipt_address GetAddress(int addressid);
        void Add_collect(Collect collect);
        Collect searchCollect(int userid, int goodid);
        IEnumerable<Collect> GetCollects(int userid);
        void Delect_Collect(int id);
      
    }
}
