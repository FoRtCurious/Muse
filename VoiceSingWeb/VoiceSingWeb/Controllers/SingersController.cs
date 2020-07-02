using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using VoiceSingWeb.Models;
using Models;

namespace VoiceSingWeb.Controllers
{
    public class SingersController : Controller
    {
        SingMusicDataBaseEntities db = new SingMusicDataBaseEntities();
        UserManager usermanager = new UserManager();
        MusicManager musicmanager = new MusicManager();
        UserLeaveManager userleavemanager = new UserLeaveManager();
        User_friendsManager userfriendsmanager = new User_friendsManager();
        ActiveManager  activemanager = new ActiveManager ();
        CircleManager cieclemanager = new CircleManager();
        // GET: Singers

        public ActionResult Index()
        {
            return View();
        }

        #region 进入歌手详情页 UserSingerInfo
        public ActionResult UserSingerInfo(int id)
        {
            UserSingerInfoViewModels Usi = new UserSingerInfoViewModels();
            var ID = Convert.ToInt32(Session["UserId"]);   //如果是自己就跳转到自己的个人中心
            if (ID == id)
            {
                return RedirectToAction("UserInfo", "UserManage");
            }
            else
            {
                Usi.user = usermanager.GetUserById(id);
                Usi.musics = musicmanager.GetMusicByUserId(id).Take(3);
                return View(Usi);
            }
        }
        #endregion

        #region 歌手详情页显示留言内容 UserLeave
        public ActionResult UserLeave(int id)
        {
            var Leave = userleavemanager.GetUserLeaveById(id).OrderByDescending(o => o.Leave_time);
            return View(Leave);
        }
        #endregion

        #region    //精选音乐人 Singer
        public ActionResult Singer()
        {

            var Singer1 = usermanager.GetUser().Where(o => o.user_info == "音乐创作人");
            return View(Singer1);
        }
        #endregion

        #region   音乐人活动 SingerActivity
        public ActionResult SingerActivity()
        {
            var activity = activemanager.GetActiveByJoinsum();
            return View(activity);
        }
        #endregion

        #region   话题Topic   未三层
        public ActionResult Topic()
        {
            var Topic = db.Topic.Where(o => o.Varify == "通过").Take(3);
            return View(Topic);
        }
        #endregion

        #region 查看用户音乐人个人信息 userSingerDetails
        public ActionResult userSingerDetails(int id)
        {
            var ID = Convert.ToInt32(Session["UserId"]);   //如果是自己就跳转到自己的个人中心
            if (id == ID)
            {
                return RedirectToAction("UserInfo", "UserManage");
            }
            else
            {
                var usersinger = db.Users.Where(o => o.userId == id).SingleOrDefault();
                return View(usersinger);
            }
        }
        #endregion

        #region  //个人信息页显示已评论内容 allLeaveMg    未三层
        public ActionResult allLeaveMg(int id)
        {
            var Leave = db.UserLeave.Where(o => o.user_id == id).OrderByDescending(o => o.Leave_time);
            return View(Leave);
        }
        #endregion

        #region   //音乐人页面依据歌手进行分类的专辑  SingerAlbum
        public ActionResult SingerAlbum(int id)
        {
            var ID = Convert.ToInt32(Session["userId"]);   //如果是自己就跳转到自己的个人中心
            if (id == ID)
            {
                return RedirectToAction("UserInfo", "UserManage");
            }
            else
            {
                var usersinger = db.Users.Where(o => o.userId == id).SingleOrDefault();
                return View(usersinger);
            }
        }
        #endregion



        #region 音乐人歌单留言     增加留言   new 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostAlbumLeave(FormCollection forms)
        {
            if (Session["UserId"] != null)
            {
                var userid = Convert.ToInt32(Session["userId"]);
                var albumid = Convert.ToInt32(forms["id"]);
                var content = forms["content"];
                var leave = cieclemanager.PostAlbumLeave(userid, albumid, content);

                if (leave == "success")
                {
                    return Content("success");
                }
                else
                {
                    return Content("fail");
                }
            }
            else
            {
                return Content("fail");
            }
 
        }

        #endregion

        #region 活动歌单留言     增加留言   new 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostActiveLeave(FormCollection forms)
        {
            var userid = Convert.ToInt32(Session["userId"]);
            var activeid = Convert.ToInt32(forms["id"]);
            var content = forms["content"];
            var leave = cieclemanager.PostActiveLeave(userid, activeid, content);

            if (leave == "success")
            {
                return Content("success");
            }
            else
            {
                return Content("fail");
            }
        }

        #endregion

        #region 音乐人歌单留言   展示    new
        public ActionResult AllLeave(int id)
        {
            var leave = cieclemanager.GetAllLeaveById(id);
            return View(leave);
        }

        #endregion

        #region 活动歌单留言   展示    new
        public ActionResult CampLeave(int id)
        {
            var leave = cieclemanager.GetAllLeaveByIdForActive(id);
            return View(leave);
        }

        #endregion




        #region     //音乐人歌单详情分页  SA1
        public ActionResult SA1(int id)
        {
            var salbum = musicmanager.GetMusicByUserId(id);
            return View(salbum);
        }
        #endregion

        #region  //音乐人歌单粉丝页面 
        public ActionResult SA2(int id)
        {
            var albumfans = userfriendsmanager.GetUserFansById(id);
            return View(albumfans);
            
        }
        #endregion

        #region //音乐人进入活动专辑页面 
        public ActionResult CampAlbum(int id)
        {
            //var campalbum = activemanager.GetCampAlbum(id);
            var campalbum = db.Active.Where(o => o.actno == id).SingleOrDefault();
            return View(campalbum);
        }
        #endregion

        #region //活动歌单详情分页获取歌曲
        public ActionResult CA1(int id)
        {
            var actalbum = activemanager.GetMusicByActiveId(id);
            return View(actalbum);

        }
        #endregion


    }
}