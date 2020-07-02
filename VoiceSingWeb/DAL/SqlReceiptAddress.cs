using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using System.Data.Entity;

namespace DAL
{
    public class SqlReceiptAddress:IReceiptAddress
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public List<Receipt_address> GetReceiptAddressJson()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var address = db.Receipt_address.ToList();
            return address;
        }

        public void Add_address(Receipt_address addr)
        {
            db.Receipt_address.Add(addr);
            db.SaveChanges();
        }
        public void Update_adddress(Receipt_address addr)
        {
            db.Set<Receipt_address>().Attach(addr);
            db.Entry<Receipt_address>(addr).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delect_address(int id)
        {
            Receipt_address receiptadd = db.Receipt_address.Where(o => o.addressid == id).FirstOrDefault();
            db.Receipt_address.Remove(receiptadd);
            db.SaveChanges();
        }

        public IEnumerable<Receipt_address> GetReceipt_Addresses(int userid)
        {
            var MyAddr = db.Receipt_address.Where(o => o.userid == userid);
            return MyAddr;
        }

        public IEnumerable<Receipt_address> MyOrderaddress(int userid)
        {
            var orderaddress = db.Receipt_address.Where(o => o.userid == userid);
            return orderaddress;
        }
        public Receipt_address GetAddress(int addressid)
        {
            var Address = db.Receipt_address.Find(addressid);
            return Address;
        }
    }
}
