using System.Collections.Generic;
using DALFactory;
using Models;
using IDAL;

namespace BLL
{
    public class ActiveManager
    {
        IActive iactive = DataAccess.CreateActive();
        public IEnumerable<ActiveAlbum> GetMusicByActiveId(int id)     //活动音乐专辑 
        {
            var actmusics = iactive.GetMusicByActiveId(id);
            return actmusics;
        }
 
        public string HideActive(int id, int userid)          //屏蔽活动
        {
            string msg = iactive.HideActive(id, userid);
            if (msg == "exist")
            {
                return msg;
            }
            else if (msg == "success")
            {
                return msg;
            }
            else
            {
                return msg;
            }
        }

        public IEnumerable<View_showactive> GetActiveByView()      //活动主页展示活动
        {
            var active = iactive.GetActiveByView();
            return active;
        }

        public IEnumerable<Activehide> GetHideActive(int id)         //new 
        {
            var active = iactive.GetHideActive(id);
            return active;
        }

        public string PublishActive(string actname, string actinfo, string orienroll, string recenroll, string image_url, int Holder)  //new
        {
            string msg = iactive.PublishActive( actname,  actinfo,  orienroll,  recenroll,  image_url,  Holder);
            if (msg == "success")
            {
                return msg;
            }
            else
            {
                return msg;
            }
        }
        public IEnumerable<Active> GetActiveByJoinsum()     //音乐人主页展示活动
        {
            var active = iactive.GetActiveByJoinsum();
            return active;
        }
        public IEnumerable<Active> GetCampAlbum(int id)
        {
            var album = iactive.GetCampAlbum(id);
            return album;
        }

        public IEnumerable<Active> GetActiveByLocation()
        {
            var active = iactive.GetActiveByLocation();
            return active;
        }

        public IEnumerable<Active> GetAllActive()
        {
            var active = iactive.GetAllActive();
            return active;
        }

        public IEnumerable<Active> GetActiveByHolder()
        {
            var active = iactive.GetActiveByHolder();
            return active;
        }

        public IEnumerable<Active> GetActiveById(int id)
        {
            var active = iactive.GetActiveById(id);
            return active;
        }

        public Active GetActiveByActno(int id)
        {
            var active = iactive.GetActiveByActno(id);
            return active;
        }

        public string ComplainActive(int userid, int actid, string content)
        {
            string msg = iactive.ComplainActive(userid, actid, content);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }






    }
}
