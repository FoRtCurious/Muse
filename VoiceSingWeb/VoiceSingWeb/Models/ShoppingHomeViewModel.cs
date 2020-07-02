using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace VoiceSingWeb.Models
{
    public class ShoppingHomeViewModel
    {
        //商城主页所需展示
        public IEnumerable<Goods> Allgoods { get; set; }
        public IEnumerable<Goods> Suggestgoods { get; set; }
        public IEnumerable<Suggest_good> Suggest_Goods { get; set; }
        public int typecount { get; set; }//判断标准
    }
}