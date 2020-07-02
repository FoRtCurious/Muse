using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using VoiceSingWeb.Models;
using System.Data.Entity.Validation;
using BLL;


namespace VoiceSingWeb.Controllers
{
    public class CircleController : Controller
    {
        UserManager usermanager = new UserManager();
        CircleManager circlemanager = new CircleManager();
        SingMusicDataBaseEntities db = new SingMusicDataBaseEntities();
        // GET: Circle
        public ActionResult Index()
        {
            return View();
        }

        #region   //展示音乐人动态 
        public ActionResult circle1()
        {
            var circle = circlemanager.GetCircleByUserType();
            //var circle = db.Circle.Where(o => o.Users.userType_id == 2);
            return View(circle);
        }

        #endregion

        #region   //展示精选音乐人 
        public ActionResult circle2()
        {
            var user = circlemanager.GetUserForCircleByFans();
            //var user = db.Users.OrderByDescending(o => o.user_fans).Take(5);
            return View(user);
        }
        #endregion

        #region   // 全部动态
        //展示所有动态 
        public ActionResult allcircle()
        {
            var circle = circlemanager.GetCircleByUptime();
            //var circle = db.Circle.OrderByDescending(o => o.uptime);
            return View(circle);
        }

        public ActionResult all()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var user = usermanager.GetUserById(id);
            return View(user);
        }
        #endregion

        #region  //重构圈子  主页头部用个人信息
        public ActionResult circle()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var user = usermanager.GetUserById(id);
            return View (user);
        }
        #endregion

        #region   //热门音乐人   头部用个人信息
        public ActionResult hot()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var user = usermanager.GetUserById(id);
            return View(user);
        }

        #endregion

        #region //个人动态   获取个人发布的圈子内容
        public ActionResult circle3()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var circle = circlemanager.GetCircleById(id);
            return View(circle);
            
        }
        #endregion

        #region   //点赞动态
        public ActionResult Like(int? id)        //用户功能，需要登录
        {
            if (Session["UserId"] != null)
            {
                var circle = db.Circle.Where(o => o.cno == id).SingleOrDefault();
                circle.thumbs ++ ;
                if (db.SaveChanges() > 0)
                    return Content("<script>alert('点赞成功！');history.go(-1); </script>; ");
               
                else
                    return Content("<script>alert('点赞失败！');history.go(-1);</script>");
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }
        #endregion

        #region  圈子详情  添加回复    circledetail     AddReply
        public ActionResult circledetail (int id )
        {
            var circle = circlemanager.CircleById(id);
            return View(circle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReply(FormCollection forms)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var cno = Convert.ToInt32(forms["cno"]);
            var content = forms["content"];
            var reply = circlemanager.AddReply(userid, cno, content);

            if (reply == "success")
            {
                return Content("success");
            }
            else
            {
                return Content("fail");
            }
        }

        #endregion

        #region 单个动态所有回复展示  AllReply  添加楼中楼回复  AddUserReply
        public ActionResult AllReply(int cno)
        {
            var reply = circlemanager.GetAllReplyByCno(cno);
            return View(reply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserReply(FormCollection forms)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var replyid = Convert.ToInt32(forms["id"]);
            var content = forms["content"];
            var reply = circlemanager.AddUserReply(userid, replyid, content);

            if (reply == "success")
            {
                return Content("success");
            }
            else
            {
                return Content("fail");
            }
        }

        #endregion

        #region  圈子详情用户回复   detailreply
        public ActionResult detailreply(int id)
        {
            var reply = circlemanager.GetAllReplyById(id);
            return View(reply);
        }

        #endregion

        #region 投诉圈子内容
        public ActionResult CircleComplain(int id)
        {
            var circle = circlemanager.CircleById(id);
            return View(circle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CircleComplain(FormCollection forms)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var id = forms["cirid"];
            var cirid = Convert.ToInt32(id);
            var content = forms["content"];
            var complain = circlemanager.ComplainCircle(userid, cirid, content);

            if (complain == "success")
            {
                return Content("<script>alert('投诉成功！');history.go(-1)</script>");
            }
            else
            {
                return Content("<script>alert('投诉失败！');history.go(-1)</script>");
            }

        }

        #endregion


        #region  zone 投诉用户
        public ActionResult ZoneComplain(int id)
        {
            var user = usermanager.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ZoneComplain(FormCollection forms)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var id = Convert.ToInt32(forms["id"]);
          //  var id = Convert.ToInt32(id);
            var content = forms["content"];
            var complain = circlemanager.ComplainUser(userid, id, content);

            if (complain == "success")
            {
                return Content("<script>alert('投诉成功！');history.go(-1)</script>");
            }
            else
            {
                return Content("<script>alert('投诉失败！');history.go(-1)</script>");
            }
        }


        #endregion

        #region  Zone圈子个人中心
        public ActionResult Zone (int id)
        {
            var user = usermanager.GetUserById(id);
            return View(user);
        }
        #endregion

        #region 圈子详情 
        public ActionResult ZoneDetails ( int id)
        {
            var circle = circlemanager.GetCircleById(id);
            return View(circle);
        }
        #endregion

    }
}