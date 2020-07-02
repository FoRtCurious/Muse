using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
    public class MusicCommentManager
    {
        IMusicComment imusiccomment = DataAccess.CreateMusicComment();
        
        public IEnumerable<MusicComment> GetMusicComment()
        {
            return imusiccomment.GetMusicComment();
        }
        public string AddComment(MusicComment comment)
        {
            return imusiccomment.AddComment(comment);
        }
        public IEnumerable<MusicComment> GetMusicCommentByMusicId(int id)
        {
            return imusiccomment.GetMusicCommentByMusicId(id);
        }
    }
}
