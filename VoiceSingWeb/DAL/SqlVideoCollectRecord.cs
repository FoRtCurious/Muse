using System.Collections.Generic;
using System.Linq;
using Models;
using IDAL;

namespace DAL
{
    public class SqlVideoCollectRecord:IVideoCollectRecord
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<VideoCollectRecord> GetRecordByUserId(int id)
        {
            var record = db.VideoCollectRecord.Where(o => o.user_id == id);
            return record;
        }
        public VideoCollectRecord GetVideoRecordByUserIdAndVideoId(int userid, int videoid)
        {
            var record = db.VideoCollectRecord.Where(o => o.user_id == userid && o.video_id == videoid).SingleOrDefault();
            return record;
        }
        public string AddVideoRecord(VideoCollectRecord record)
        {
            db.VideoCollectRecord.Add(record);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
        public string RemoveVideoRecord(VideoCollectRecord record)
        {
            db.VideoCollectRecord.Remove(record);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
    }
}
