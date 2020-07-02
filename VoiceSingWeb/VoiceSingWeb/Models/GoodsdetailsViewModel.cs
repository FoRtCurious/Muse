using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Data.Entity.Core.Objects;

namespace VoiceSingWeb.Models
{
    public class GoodsdetailsViewModel
    {//商品详情页面要展示的内容
        public Goods Goodsdatail { get; set; }
        public IEnumerable<GoodsComment> Comments { get; set; }
        public IEnumerable<GoodsComment> CommentsImg { get; set; }
        public IEnumerable<GoodsComment> CommentsGood { get; set; }
        public IEnumerable<GoodsComment> CommentsBad { get; set; }
        public ObjectResult<int?> Sorce { get; set; }
        public IEnumerable<Add_comment> Add_comment { get; set; }
    }
}