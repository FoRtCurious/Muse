using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceSingWeb.Models
{
    public class PlusGoodsCommentModel
    {//追评页面要展示的内容
        public int commentid { get; set; }
        public int goodid { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public string img { get; set; }
        public string Time { get; set; }
    }
}