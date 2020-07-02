using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using Models;
using IDAL;

namespace BLL
{
    public class VideoManager
    {
        IVideo ivideo = DataAccess.CreateVideo();
        public IEnumerable<Videos> GetVideo()
        {
            var videos = ivideo.GetVideo();
            return videos;
        }
        public Videos GetVideoById(int id)
        {
            var video = ivideo.GetVideoById(id);
            return video;
        }
        public IEnumerable<Videos> GetVideoByUserId(int id)
        {
            return ivideo.GetVideoByUserId(id);
        }
        public void AddLookTime(Videos v)
        {
            ivideo.AddLookTime(v);
        }
        public IEnumerable<Videos> SearchVideo(string searchString)
        {
            return ivideo.SearchVideo(searchString);
        }
        public List<Videos> GetVideoJson()
        {
            var videos = ivideo.GetVideoJson();
            return videos;
        }
        public Videos SearchVideoById(int id)
        {
            var video = ivideo.SearchVideoById(id);
            return video;
        }
        public string CloseVideo(int id)
        {
            return ivideo.CloseVideo(id);
        }
        public string OpenVideo(int id)
        {
            return ivideo.OpenVideo(id);
        }
        public string AgreeVideoCheck(int id)
        {
            return ivideo.AgreeVideoCheck(id);
        }
        public string UnAgreeVideoCheck(int id)
        {
            return ivideo.UnAgreeVideoCheck(id);
        }
        public string AddVideo(Videos video)
        {
            return ivideo.AddVideo(video);
        }
        public string RemoveVideo(Videos video)
        {
            return ivideo.RemoveVideo(video);
        }
    }
}
