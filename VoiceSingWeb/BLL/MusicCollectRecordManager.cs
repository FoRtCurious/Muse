using System.Collections.Generic;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
    public class MusicCollectRecordManager
    {
        IMusicCollectRecord imusiccolrecord = DataAccess.CreateMusicCollectRecord();
        public IEnumerable<MusicCollectRecord> GetRecordByUserId(int id)
        {
            var record = imusiccolrecord.GetRecordByUserId(id);
            return record;
        }
        public MusicCollectRecord GetRecordByUserIdAndMusicId(int userid, int musicid)
        {
            return imusiccolrecord.GetRecordByUserIdAndMusicId(userid,musicid);
        }
        public string AddMusicCollect(MusicCollectRecord record)
        {
            return imusiccolrecord.AddMusicCollect(record);
        }
        public string RemoveMusicCollect(MusicCollectRecord record)
        {
            return imusiccolrecord.RemoveMusicCollect(record);
        }       
    }
}
