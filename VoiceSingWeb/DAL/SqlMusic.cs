using System.Collections.Generic;
using System.Linq;
using Models;
using IDAL;

namespace DAL
{
    public class SqlMusic:IMusic
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();

        public IEnumerable<UserMusics> GetMusic()
        {
            var musics = db.UserMusics.ToList();
            return musics;
        }
        public IEnumerable<UserMusics> GetOriginMusic()
        {
            var musics = db.UserMusics.Where(o => o.UpType.typeName == "原创").ToList();
            return musics;
        }
        public IEnumerable<UserMusics> GetCoverMusic()
        {
            var musics = db.UserMusics.Where(o => o.UpType.typeName == "翻唱").ToList();
            return musics;
        }
        public IEnumerable<UserMusics> SearchMusic(string searchString)
        {
            var musics = from o in db.UserMusics
                         where o.music_name.Contains(searchString) || o.Users.name.Contains(searchString)  //根据歌名或者歌手名模糊查询歌曲
                         select o;            
            return musics;
        }
        public void AddListenTime(UserMusics music)
        {
            music.listen_times += 1;
            db.SaveChanges();
        }
        public IEnumerable<UserMusics> GetMusicByUserId(int id)
        {
            var musics = db.UserMusics.Where(o => o.user_id == id);
            return musics;
        }
        public UserMusics GetMusicById(int id)
        {
            var music = db.UserMusics.Find(id);
            return music;
        }
        public string AddLike(UserMusics music)
        {
            music.music_like++;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
        public List<UserMusics> GetMusicJson()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var music = db.UserMusics.ToList();
            return music;
        }
        public string CloseMusic(int id)
        {
            var music = db.UserMusics.Find(id);
            music.music_state = 0;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
        public string OpenMusic(int id)
        {
            var music = db.UserMusics.Find(id);
            music.music_state = 1;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
        public UserMusics SearchMusicById(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var music = db.UserMusics.Find(id);
            return music;
        }
        public IEnumerable<UpType> GetUpType()
        {
            var uptype = db.UpType.ToList();
            return uptype;
        }
        public string AgreeCheck(int id)
        {
            var music = db.UserMusics.Find(id);
            music.music_check = 1;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public string UnAgreeCheck(int id)
        {
            var music = db.UserMusics.Find(id);
            db.UserMusics.Remove(music);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public string AddMusic(UserMusics music)
        {
            db.UserMusics.Add(music);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public string RemoveMusic(UserMusics music)
        {
            db.UserMusics.Remove(music);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public IEnumerable<PlayRecord> GetPlayRecordByUserId(int id)
        {
            var record = db.PlayRecord.Where(o => o.user_id == id).ToList();
            return record;
        }
    }
}
