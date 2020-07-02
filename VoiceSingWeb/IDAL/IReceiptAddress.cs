using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IReceiptAddress
    {
        List<Receipt_address> GetReceiptAddressJson();

        IEnumerable<Receipt_address> GetReceipt_Addresses(int userid);
        //找到用户所对应的收货地址
        void Add_address(Receipt_address addr);
        //添加收货地址
        void Delect_address(int id);
        //删除收货地址
        Receipt_address GetAddress(int addressid);
        //得到对应得收货地址，准备修改
        void Update_adddress(Receipt_address addr);
        //修改收货地址
        IEnumerable<Receipt_address> MyOrderaddress(int userid);
        //购买商品页面展示收货地址    
    }
}
