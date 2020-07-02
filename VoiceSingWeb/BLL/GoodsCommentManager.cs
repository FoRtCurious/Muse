using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using Models;
using IDAL;
using System.Data.Entity.Core.Objects;

namespace BLL
{
   public class GoodsCommentManager
    {
        IGoodsComment igoodsComment = DataAccess.CreateGoodsComment();
        public ObjectResult<int?> Sorce(int? id)
        {
            return igoodsComment.Sorce(id);
        }
        public IEnumerable<GoodsComment> GetComments(int id)
        {
            var comment = igoodsComment.GetComments(id);
            return comment;
        }
        public IEnumerable<GoodsComment> GetCommentsImg(int id)
        {
            var comment = igoodsComment.GetCommentsImg(id);
            return comment;
        }
        public IEnumerable<GoodsComment> GetCommentsGood(int id)
        {
            var comment = igoodsComment.GetCommentsGood(id);
            return comment;
        }
        public IEnumerable<GoodsComment> GetCommentsBad(int id)
        {
            var comment = igoodsComment.GetCommentsBad(id);
            return comment;
        }


        public int Comment_number(int userid)
        {
            var sum = igoodsComment.Comment_number(userid);
            return sum;
        }
        public IEnumerable<orderdetail_View> GetOrderdetail_Views(int userid)
        {
            var Mycomment = igoodsComment.GetOrderdetail_Views(userid);
            return Mycomment;
        }
        public Orderdetails orderdetails(int id)
        {
            var details = igoodsComment.orderdetails(id);
            return details;
        }
        public void Save()
        {
            igoodsComment.Save();
        }
        public void AddComment(GoodsComment comment)
        {
            igoodsComment.AddComment(comment);
        }
        public IEnumerable<GoodsComment> GetMyComments(int userid)
        {
            var comments = igoodsComment.GetMyComments(userid);
            return comments;
        }
        public GoodsComment GetNowComment(int id)
        {
            var comment = igoodsComment.GetNowComment(id);
            return comment;
        }
        public void PlusAddComment(Addcomment addcomment)
        {
            igoodsComment.PlusAddComment(addcomment);
        }
        public IEnumerable<Add_comment> GetAdd_Comments(int id)
        {
            var comment = igoodsComment.GetAdd_Comments(id);
            return comment;
        }
        public GoodsComment GetMyNowComment(int id)
        {
            var comment = igoodsComment.GetMyNowComment(id);
            return comment;
        }
        public void GoodComment_update(GoodsComment comment)
        {
            igoodsComment.GoodComment_update(comment);
        }
    }
}
