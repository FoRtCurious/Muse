using System.Collections.Generic;
using Models;

namespace IDAL
{
    public interface IMusicCollectRecord
    {
        IEnumerable<MusicCollectRecord> GetRecordByUserId(int id);
        MusicCollectRecord GetRecordByUserIdAndMusicId(int userid,int musicid);
        string AddMusicCollect(MusicCollectRecord record);
        string RemoveMusicCollect(MusicCollectRecord record);
    }
}
