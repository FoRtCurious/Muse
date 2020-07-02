using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IVideoComment
    {
        IEnumerable<VideoComment> GetVideoComment();
        string AddComment(VideoComment comment);
    }
}
