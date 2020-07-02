using Models;
using System.Collections.Generic;

namespace IDAL
{
    public interface IVideoCollectRecord
    {
        IEnumerable<VideoCollectRecord> GetRecordByUserId(int id);
        VideoCollectRecord GetVideoRecordByUserIdAndVideoId(int userid, int videoid);
        string AddVideoRecord(VideoCollectRecord record);
        string RemoveVideoRecord(VideoCollectRecord record);
    }
}
