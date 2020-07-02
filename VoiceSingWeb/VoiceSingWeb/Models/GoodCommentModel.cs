using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceSingWeb.Models
{
    public class GoodCommentModel
    {//评论准备，展示要评论的商品相关信息
        public int orderdetailsid { get; set; }
        public int goodid { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string img { get; set; }
    }
}