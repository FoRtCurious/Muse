using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity.Core.Objects;

namespace IDAL
{
    public interface IGoodsComment
    {
        ObjectResult<int?> Sorce(int? id);
        //利用存储过程得到评论分数
        IEnumerable<GoodsComment> GetCommentsImg(int id);
        //得到有图评价
        IEnumerable<GoodsComment> GetCommentsGood(int id);
        //得到好评
        IEnumerable<GoodsComment> GetCommentsBad(int id);
        //得到差评
        IEnumerable<GoodsComment> GetComments(int id);
        //得到对应商品评论
        IEnumerable<GoodsComment> GetMyComments(int userid );
        //得到我的评价
        GoodsComment GetMyNowComment(int id);
        //得到追评的评论
        GoodsComment GetNowComment(int id);
        //评论准备
        int Comment_number(int userid);
        //得到待评论商品（根据已买商品订单详情）
        void GoodComment_update(GoodsComment comment);
        IEnumerable<orderdetail_View> GetOrderdetail_Views(int userid);
        //得到我的待评论商品（视图）
        Orderdetails orderdetails(int id);
        //找到对应订单详情，修改评论字段
        void Save();
        void AddComment(GoodsComment comment);
        //添加评论
        void PlusAddComment(Addcomment addcomment);

        IEnumerable<Add_comment> GetAdd_Comments(int id);
    }
}
