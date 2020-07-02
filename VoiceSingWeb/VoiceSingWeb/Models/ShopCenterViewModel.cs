using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceSingWeb.Models
{
    public class ShopCenterViewModel
    { //个人中心所需展示
        public IEnumerable<Orders> MyOrder { get; set; }
        public IEnumerable<Receipt_address> MyAddr { get; set; }
        public IEnumerable<Collect> MyCollect { get; set; }
        public IEnumerable<orderdetail_View> MyComment { get; set; }
        public IEnumerable<GoodsComment> Comments { get; set; }
    }
}