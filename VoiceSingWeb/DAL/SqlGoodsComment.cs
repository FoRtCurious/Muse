using System.Collections.Generic;
using System.Linq;
using IDAL;
using Models;
using System;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class SqlGoodsComment:IGoodsComment
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();

        public ObjectResult<int?> Sorce(int? id)
        {
            return db.Sorce_avg(id);
        }
        public IEnumerable<GoodsComment> GetComments(int id)
        {
            var commment = db.GoodsComment.Where(o => o.goodsid == id);
            return commment;
        }
        public IEnumerable<GoodsComment> GetCommentsImg(int id)
        {
            var comment = db.GoodsComment.Where(o => o.goodsid == id && o.content.Contains("<img"));
            return comment;
        }
        public IEnumerable<GoodsComment> GetCommentsGood(int id)
        {
            var comment = db.GoodsComment.Where(o => o.goodsid == id && o.Sorce >= 4);
            return comment;
        }
        public IEnumerable<GoodsComment> GetCommentsBad(int id)
        {
            var comment = db.GoodsComment.Where(o => o.goodsid == id && o.Sorce < 3);
            return comment;
        }

        public int Comment_number(int userid)
        {
            var sum = db.orderdetail_View.Where(o => o.userId == userid).Count();
            return sum;
        }

        public IEnumerable<orderdetail_View> GetOrderdetail_Views(int userid)
        {
            var Mycomment = db.orderdetail_View.Where(o => o.userId == userid);
            return Mycomment;
        }

        public Orderdetails orderdetails(int id)
        {
            var details = db.Orderdetails.Find(id);
            return details;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void AddComment(GoodsComment comment)
        {
            db.GoodsComment.Add(comment);
            db.SaveChanges();
        }

        public IEnumerable<GoodsComment> GetMyComments(int userid )
        {
            var comments = db.GoodsComment.Where(o => o.userId == userid && o.addcom==0);
            return comments;
        }

       public  GoodsComment GetNowComment(int id)
        {
            var comment = db.GoodsComment.Find(id);
            return comment;
        }

        public void PlusAddComment(Addcomment addcomment)
        {
            db.Addcomment.Add(addcomment);
            db.SaveChanges();
        }

        public IEnumerable<Add_comment> GetAdd_Comments(int id)
        {
            var comment = db.Add_comment.Where(o => o.goodsid == id);
            return comment;
        }

        public GoodsComment GetMyNowComment(int id)
        {
            var comment = db.GoodsComment.Where(o => o.goodscommentid == id).First();
            return comment; 
        }

        public void GoodComment_update(GoodsComment comment)
        {
            db.Set<GoodsComment>().Attach(comment);
            db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}