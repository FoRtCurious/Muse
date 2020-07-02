using System.Collections.Generic;
using System.Linq;
using IDAL;
using Models;

namespace DAL
{
    public class SqlMusicComment : IMusicComment
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<MusicComment> GetMusicComment()
        {
            var musiccomment = db.MusicComment.ToList();
            return musiccomment;
        }
        public string AddComment(MusicComment comment)
        {
            db.MusicComment.Add(comment);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
        public IEnumerable<MusicComment> GetMusicCommentByMusicId(int id)
        {
            var comment = db.MusicComment.Where(o => o.music_id == id);
            return comment;
        }
    }
}
