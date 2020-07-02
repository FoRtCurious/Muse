using System.Linq;
using Models;
using System;
using System.Data.Entity;
using IDAL;
using System.Collections.Generic;

namespace DAL
{
    public class SqlActive : IActive
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();

        public IEnumerable<ActiveAlbum> GetMusicByActiveId(int id)
        {
            var actmusics = db.ActiveAlbum.Where(o => o.Activeid == id).Take(10);
            return actmusics;
        }
        #region   //屏蔽活动 
        public string HideActive(int id, int userid)
        {
            var i = id;
            string msg;
            var User = db.Activehide.Where(o => o.activeid == i).SingleOrDefault();
            if (User != null)
            {
                msg = "exist";
                return msg;
            }
            else
            {
                //初始化一个新邮件
                Activehide hide = new Activehide();
                hide.userid = userid;
                hide.activeid = id;
                hide.hide_time = DateTime.Now;
                hide.hide_state = 0;
                db.Activehide.Add(hide);

                if (db.SaveChanges() > 0)
                {
                    msg = "success";
                    return msg;
                }
                else
                {
                    msg = "fail";
                    return msg;
                }
            }
        }
        #endregion

        public IEnumerable<View_showactive> GetActiveByView()
        {
            var act = db.View_showactive.ToList().Take(3);
            //var act = db.Active.Include("Activehide").Where(o => o.Location == 3 /*&& o.hide_state == 0*/).Take(3);
            return act;
        }

        public IEnumerable<Activehide> GetHideActive(int id)                    //new 
        {
            var active = db.Activehide.Where(o => o.userid == id);
            return active;
        }

        public string PublishActive(string actname, string actinfo, string orienroll, string recenroll, string image_url, int Holder)   //new 
        {
            string msg;
            //初始化一个活动
            Active active = new Active();
            active.actname = actname;
            active.actinfo = actinfo;
            active.orienroll = orienroll;
            active.recenroll = recenroll;
            active.image_url = image_url;
            active.Joinsum = 0;
            active.Viewsum = 1;
            active.DDLine = null;   
            active.Holder = Convert.ToInt32(Holder);
            active.Location = 3;
            active.ac_state = 1;    // 状态未1标识审核状态
            db.Active.Add(active);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }
        }

        public IEnumerable<Active> GetActiveByJoinsum()
        {
            var activity = db.Active.OrderByDescending(o => o.Joinsum).Take(3);
            return activity;
        }

        public IEnumerable<Active> GetCampAlbum(int id)
        {
            var campalbum = db.Active.Where(o => o.actno == id);
            return campalbum;
        }

        public IEnumerable<Active> GetActiveByLocation()
        {
            var used = db.Active.Where(o => o.Location == 1).Where(o => o.ac_state == 0);
            return used;
        }

        public IEnumerable<Active> GetAllActive()
        {
            var all = db.Active.ToList().Where(o => o.ac_state == 0);
            return all;
        }

        public IEnumerable<Active> GetActiveByHolder()
        {
            var likecamp = db.Active.Where(o => o.Holder == 20191048).Where(o => o.ac_state == 0).Take(3);
            return likecamp;
        }

        public IEnumerable<Active> GetActiveById(int id)    //我的发布
        {
            var mycamp = db.Active.Where(o => o.Holder == id);
            return mycamp;
        }

        public Active GetActiveByActno(int id)
        {
            var active = db.Active.Where(o => o.actno == id).SingleOrDefault();
            return active;
        }

        public string ComplainActive(int userid, int actid, string content)
        {
            string msg;
            var active = db.Active.Find(actid);
            active.ac_state = 1;
            //初始化一个投诉事件
            ActiveComplain complain = new ActiveComplain();
            complain.userid = userid;
            complain.activeid = actid;
            complain.content = content;
            complain.complain_time = DateTime.Now;
            complain.complain_state = 1;
            db.ActiveComplain.Add(complain);

            if (db.SaveChanges () > 0 )
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }
        }




    }
}
