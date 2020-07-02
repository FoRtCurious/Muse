using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceSingWeb.Models
{
    public class PlaceOrderModel
    {
       //立即购买所需传的数据
            public int Userid { get; set; }
            public int Goodid { get; set; }
            public string Image { get; set; }
            public decimal Tot_amt { get; set; }
            public int Qty { get; set; }
            public string Goodname { get; set; }
            public decimal Price { get; set; }
       
    }
}