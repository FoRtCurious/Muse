using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlVideo:IVideo
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Videos> GetVideo()
        {
            var Videos = db.Videos.ToList();
            return Videos;
        }
        public Videos GetVideoById(int id)
        {
            var video = db.Videos.Find(id);
            return video;
        }
        public IEnumerable<Videos> GetVideoByUserId(int id)
        {
            var videos = db.Videos.Where(o => o.user_id == id).ToList();
            return videos;
        }
        public void AddLookTime(Videos v)
        {
            v.video_look += 1;
            db.SaveChanges();
        }
        public List<Videos> GetVideoJson()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var videos = db.Videos.ToList();
            return videos;
        }
        public IEnumerable<Videos> SearchVideo(string searchString)
        {
            var videos = from o in db.Videos
                         where o.video_name.Contains(searchString)  //根据输入字段模糊查询视频
                         select o;
            return videos;
        }
        public Videos SearchVideoById(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var video = db.Videos.Find(id);
            return video;
        }
        public string CloseVideo(int id)
        {
            var video = db.Videos.Find(id);
            video.video_state = 0;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public string OpenVideo(int id)
        {
            var video = db.Videos.Find(id);
            video.video_state = 1;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public string AgreeVideoCheck(int id)
        {
            var video = db.Videos.Find(id);
            video.video_check = 1;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public string UnAgreeVideoCheck(int id)
        {
            var video = db.Videos.Find(id);
            db.Videos.Remove(video);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        public string AddVideo(Videos video)
        {
            db.Videos.Add(video);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
        public string RemoveVideo(Videos video)
        {
            db.Videos.Remove(video);
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        }
    }
}
