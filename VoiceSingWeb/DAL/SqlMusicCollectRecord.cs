using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    class SqlMusicCollectRecord:IMusicCollectRecord
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<MusicCollectRecord> GetRecordByUserId(int id)
        {
            var record = db.MusicCollectRecord.Where(o => o.user_id == id);
            return record;
        }
        public MusicCollectRecord GetRecordByUserIdAndMusicId(int userid, int musicid)
        {
            var record = db.MusicCollectRecord.Where(o => o.user_id == userid && o.music_id == musicid).SingleOrDefault();
            return record;
        }
        public string AddMusicCollect(MusicCollectRecord record)
        {
            db.MusicCollectRecord.Add(record);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
        public string RemoveMusicCollect(MusicCollectRecord record)
        {
            db.MusicCollectRecord.Remove(record);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
    }
}
