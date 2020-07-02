using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace VoiceSingWeb.Models
{
    public class PlaceOrder_AddressViewModel
    {
        //立即购买所展示页面
        public List<PlaceOrderModel> orderlist { get; set; }
        public IEnumerable<Receipt_address> MyAddr { get; set; }
    }
}