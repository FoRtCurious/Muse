using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DALFactory;
using IDAL;

namespace BLL
{
    public class ReceiptAddressManager
    {
        IReceiptAddress iaddress = DataAccess.CreateReceiptAddress();
        public List<Receipt_address> GetReceiptAddressJson()
        {
            var address = iaddress.GetReceiptAddressJson();
            return address;
        }


        public IEnumerable<Receipt_address> GetReceipt_Addresses(int userid)
        {
            var MyAddr = iaddress.GetReceipt_Addresses(userid);
            return MyAddr;
        }

        public void Add_address(Receipt_address addr)
        {
            iaddress.Add_address(addr);
        }
        public void Delect_address(int id)
        {
            iaddress.Delect_address(id);
        }
        public void Update_adddress(Receipt_address addr)
        {
            iaddress.Update_adddress(addr);
        }
        public IEnumerable<Receipt_address> MyOrderaddress(int userid)
        {
            var orderaddress = iaddress.MyOrderaddress(userid);
            return orderaddress;
        }
        public Receipt_address GetAddress(int addressid)
        {
            var Address = iaddress.GetAddress(addressid);
            return Address;
        }
    }
}
