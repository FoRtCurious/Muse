
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
   public class ShopCenterManager
    {
        IShopCenter ishopcenter = DataAccess.CreateShopCenter();
        public IEnumerable<Orders> GetOrders(int userid)
        {
            var MyOrder = ishopcenter.GetOrders(userid);
            return MyOrder;
        }
        public IEnumerable<Receipt_address> GetReceipt_Addresses(int userid)
        {
            var MyAddr = ishopcenter.GetReceipt_Addresses(userid);
            return MyAddr;
        }
        public IEnumerable<Orderdetails> GetOrderdetails(int detailId)
        {
            var order_product =ishopcenter.GetOrderdetails(detailId);
            return order_product;

        }
        public void Add_address(Receipt_address addr)
        {
              ishopcenter.Add_address(addr);
        }
        public void Delect_address(int id)
        {
            ishopcenter.Delect_address(id);
        }
        public void Update_adddress(Receipt_address addr)
        {
            ishopcenter.Update_adddress(addr);
        }
        public IEnumerable<Receipt_address> MyOrderaddress(int userid)
        {
            var orderaddress = ishopcenter.MyOrderaddress(userid);
            return orderaddress;
        }
        public Receipt_address GetAddress(int addressid)
        {
            var Address = ishopcenter.GetAddress(addressid);
            return Address;
        }
        public void Add_collect(Collect collect)
        {
            ishopcenter.Add_collect(collect);
        }
        public Collect searchCollect(int userid,int goodid)
        {
            var searchcollect = ishopcenter.searchCollect(userid, goodid);
            return searchcollect;
        }
        public IEnumerable<Collect>GetCollects(int userid)
        {
            var MyCollect = ishopcenter.GetCollects(userid);
            return MyCollect;
        }
        public void Delect_Collcet(int id)
        {
            ishopcenter.Delect_Collect(id);
        }
    }
}