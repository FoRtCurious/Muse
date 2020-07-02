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
    public class VideoCollectRecordManager
    {
        IVideoCollectRecord ivideocolrecord = DataAccess.CreateVideoCollectRecord();
        public IEnumerable<VideoCollectRecord> GetRecordByUserId(int id)
        {
            var record = ivideocolrecord.GetRecordByUserId(id);
            return record;
        }
        public VideoCollectRecord GetVideoRecordByUserIdAndVideoId(int userid, int videoid)
        {
            return ivideocolrecord.GetVideoRecordByUserIdAndVideoId(userid, videoid);
        }
        public string AddVideoRecord(VideoCollectRecord record)
        {
            return ivideocolrecord.AddVideoRecord(record);
        }
        public string RemoveVideoRecord(VideoCollectRecord record)
        {
            return ivideocolrecord.RemoveVideoRecord(record);
        }
    }
}
