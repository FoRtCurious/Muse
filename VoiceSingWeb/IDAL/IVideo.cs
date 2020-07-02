using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IVideo
    {
        IEnumerable<Videos> GetVideo();
        Videos GetVideoById(int id);
        IEnumerable<Videos> GetVideoByUserId(int id);
        IEnumerable<Videos> SearchVideo(string searchString);
        void AddLookTime(Videos v);
        List<Videos> GetVideoJson();
        Videos SearchVideoById(int id);
        string CloseVideo(int id);
        string OpenVideo(int id);
        string AgreeVideoCheck(int id);
        string UnAgreeVideoCheck(int id);
        string AddVideo(Videos video);
        string RemoveVideo(Videos video);
    }
}
