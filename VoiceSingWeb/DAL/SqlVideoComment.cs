using System.Collections.Generic;
using System.Linq;
using IDAL;
using Models;

namespace DAL
{
    public class SqlVideoComment:IVideoComment
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<VideoComment> GetVideoComment()
        {
            var videocomment = db.VideoComment.ToList();
            return videocomment;
        }
        public string AddComment(VideoComment comment)
        {
            db.VideoComment.Add(comment);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
    }
}
