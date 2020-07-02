using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IMusicComment
    {
        IEnumerable<MusicComment> GetMusicComment();
        string AddComment(MusicComment comment);
        IEnumerable<MusicComment> GetMusicCommentByMusicId(int id);
    }
}
