using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class VideoCommentManager
    {
        IVideoComment ivideocomment = DataAccess.CreateVideoComment();
        public IEnumerable<VideoComment> GetVideoComment()
        {
            var videocomment = ivideocomment.GetVideoComment();
            return videocomment;
        }
        public string AddComment(VideoComment comment)
        {
            return ivideocomment.AddComment(comment);
        }
    }
}
