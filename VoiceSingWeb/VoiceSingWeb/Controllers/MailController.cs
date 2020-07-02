using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoiceSingWeb.Models;
using System.IO;
using System.Data.Entity.Validation;
using BLL;
using Models;

namespace VoiceSingWeb.Controllers
{
    public class MailController : Controller
    {
        MailsManager mailsmanager = new MailsManager();
        UserManager usermanager = new UserManager();
        User_friendsManager userfriengmanager = new User_friendsManager();
        MailsManager mailmanager = new MailsManager();
        #region  首页
        public ActionResult Index()
        {
            // if (Session["UserId"] != null)
            // {
            var id = Convert.ToInt32(Session["UserId"]);
            var user = usermanager.GetUserById(id);
            return View(user);
            //}
            // else
            // {
            //     return Content("<script>alert('请先登录！');</script>");
            // }
        }
        #endregion

        //通讯录类
        #region //我的关注  
        public ActionResult Friends()
        {
            if (Session["UserId"] != null)
            {
                var id = Convert.ToInt32(Session["UserId"]);
                var user = usermanager.GetUserById(id);
                return View(user);
            }
            else
            {
                return Content("<script>alert('请先登录！');</script>");
            }
        }
        #endregion

        #region //我的关注展示分布式图
        public ActionResult friend1(int id)
        {
            var mylike = userfriengmanager.GetUserFriendsById(id);
            return View(mylike);
        }
        #endregion

        #region //我的粉丝 
        public ActionResult Fans()
        {
            if (Session["UserId"] != null)
            {
                var id = Convert.ToInt32(Session["UserId"]);
                var user = usermanager.GetUserById(id);
                return View(user);
            }
            else
            {
                return Content("<script>alert('请先登录！');</script>");
            }
        }
        #endregion

        #region //我的粉丝展示页分布式图
        public ActionResult fans1(int id)
        {
            var myfans = userfriengmanager.GetUserFansById(id);
            return View(myfans);
        }
        #endregion

        #region 通过删除user-friends表数据实现对用户取消关注
        public ActionResult Dislike(int id)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            int dislike = mailmanager.DislikeUser(id, userid);

            if (dislike == 1)
            {
                return Content("<script>alert('取关成功！');history.go(-1)</script>");
            }
            else
                return Content("<script>alert('取关失败！');history.go(-1)</script>");
        }

        #endregion

        #region 通过删除user friends表数据对我的粉丝进行移除操作
        public ActionResult RemoveLike(int id)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            int removelike = mailmanager.RemoveLike(id, userid);
            if (removelike == 1)
            {
                return Content("<script>alert('移除成功！');history.go(-1)</script>");
            }
            else
                return Content("<script>alert('移除失败！');history.go(-1)</script>");
        }

        #endregion


        //邮件类
        #region //收件箱邮件分布式图 
        public ActionResult Rmail(int id)
        {
            var recepmail = mailsmanager.GetMailsByPhone(id);
            return View(recepmail);
        }
        #endregion

        #region //发件箱
        public ActionResult Sent()
        {
            if (Session["UserId"] != null)
            {
                var id = Convert.ToInt32(Session["UserId"]);
                var user = usermanager.GetUserById(id);
                return View(user);
            }
            else
            {
                return Content("<script>alert('请先登录！');</script>");
            }
        }
        #endregion

        #region //发件箱邮件分布式图 
        public ActionResult Smail(int id)
        {
            var sentmail = mailsmanager.GetMailsByPhone2(id);
            return View(sentmail);
        }
        #endregion

        #region //垃圾箱
        public ActionResult Rubbish()
        {
            if (Session["UserId"] != null)
            {
                var id = Convert.ToInt32(Session["UserId"]);
                var user = usermanager.GetUserById(id);
                return View(user);
            }
            else
            {
                return Content("<script>alert('请先登录！');</script>");
            }
        }
        #endregion

        #region //垃圾箱分布式图
        public ActionResult Rubmail(int id)
        {
            var rubmail = mailsmanager.GetMailsByPhone3(id);
            return View(rubmail);
        }
        #endregion


        //写信类
        #region  //写信 
        public ActionResult Write()
        {
            if (Session["UserId"] != null)
            {
                var id = Convert.ToInt32(Session["UserId"]);
                var user = usermanager.GetUserById(id);
                return View(user);
            }
            else
            {
                return Content("<script>alert('请先登录！');</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Write(FormCollection forms)
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var recip = Convert.ToInt32(forms["recip"]);
            var title = forms["title"];
            //  string content = forms["content"];
            var write = mailmanager.Write(id, recip, title, forms["content"]);

            if (write == "success")
            {
                return Content("<script>alert('发送成功！');history.go(-1)</script>");
            }
            else
                return Content("<script>alert('发送失败！');history.go(-1)</script>");
        }


        //if (ModelState.IsValid)
        //{
        //    if (forms["recip"] != "" && forms["title"] != "" && forms["mail"] != "")
        //    {
        //        string msg = mailmanager.Write(forms["recip"], forms["title"], forms["mail"]);
        //        if (msg == "exist")
        //        {
        //            return Content("exist");
        //        }
        //        else if (msg == "success")
        //        {
        //            return Content("success");
        //        }
        //        else
        //        {
        //            return Content("fail");
        //        }
        //    }
        //    else
        //    {
        //        return Content("fail");
        //    }
        //}
        //else
        //{
        //    return RedirectToAction("Write", "Mail");
        //}


        // var id = Convert.ToInt32(Session["UserId"]);
        //var recip = Convert.ToInt32(forms["recip"]);
        //    var title = forms["title"];
        //    var content = forms["content"];
        //    var write = mailmanager.Write(id, recip, title, content);

        //    if (write == "success")
        //    {
        //        return Content("<script>alert('发送成功！');history.go(-1)</script>");
        //    }
        //    else
        //        return Content("<script>alert('发送失败！');history.go(-1)</script>");

        //}
        #endregion

        #region  //邮件编辑页面  闲置 
        public ActionResult Writemail(FormCollection forms)
        {
            //var id = Convert.ToInt32(Session["UserId"]);
            //var recip = Convert.ToInt32(forms["recip"]);
            //var title = forms["title"];
            //var content = forms["content"];
            //var write = mailmanager.Write(id, recip, title, content);

            //if (write  ==  "success")
            //{
            //    return Content("<script>alert('发送成功！');history.go(-1)</script>");
            //}
            //else
            //    return Content("<script>alert('发送失败！');history.go(-1)</script>");
            return View();
        }
        #endregion

        #region 通过修改状态删除邮件     
        public ActionResult delete(int id)
        {
            int delete = mailmanager.DeleteMailByChangeState(id);

            if (delete == 1)
            {
                return Content("<script>alert('删除成功！');history.go(-1)</script>");
                //return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Content("<script>alert('删除失败！');history.go(-1)</script>");
            //return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 通过修改状态恢复邮件    
        public ActionResult Renew(int id)
        {
            int delete = mailmanager.RenewMail(id);

            if (delete == 1)
            {
                return Content("<script>alert('恢复成功！');history.go(-1)</script>");
                //return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Content("<script>alert('恢复失败！');history.go(-1)</script>");
            //return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        //私信类
        #region  //实时聊天模块首页  发送消息
        public ActionResult ChatIndex()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var user = usermanager.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SentMsg(FormCollection forms, MailChatRecords mailchatrecords)
        {
            if (Session["UserId"] != null && Session["UserName"] != null)    //用户功能，需要登录
            {
                var id = Convert.ToInt32(Session["UserId"]);
                var recipid = Convert.ToInt32(forms["recipid"]);      //调试使用 
                var recordid = Convert.ToInt32(forms["recordid"]);
                var content = forms["content"];
                var record = mailmanager.AddChatMsg(id, recipid, recordid, content);
                var newMsg = mailmanager.GetHistoryByUser(id, recipid).Where(o => o.content == content).OrderByDescending(o => o.sent_time).FirstOrDefault();
                newMsg.Users = usermanager.GetUserById(id);
                newMsg.Users1 = usermanager.GetUserById(recipid);
                if (record == "success")
                {
                    return View(newMsg);
                }
                else
                    return Content("fail");
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }


        #endregion

        #region  获取所有用户的聊天链接
        public ActionResult ChatAll()
        {
            var alluser = mailmanager.GetAllUser();
            return View(alluser);
        }

        #endregion

        #region 向MailChat表添加数据  添加可聊天用户
        public ActionResult AddChat(int recipid)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var chat = mailmanager.AddMailChat(userid, recipid);
            if (chat == "success")
            {
                return Content("<script>alert('加入最近联系人成功！');history.go(-1)</script>");
            }
            else
            {
                return Content("<script>alert('已经在最近联系人！');history.go(-1)</script>");
            }

        }

        #endregion


        #region 聊天记录  && 创建聊天
        [HttpPost]
        public ActionResult CreateChat(int recipid)
        {
            var id = Convert.ToInt32(Session["UserId"]); ;
            var history = mailmanager.GetHistoryByUser(id, recipid);
            return View(history);
        }

    
        public ActionResult ChatHistory()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var recipid = 20191053;
            var history = mailmanager.GetHistoryByUser(id, recipid);
            return View(history);
        }


        #endregion

        #region  获取最近聊天的聊天链接
        public ActionResult ChatNew()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var chatuser = mailmanager.GetAllChatByUser(id);
            return View(chatuser);
        }

        #endregion

        #region 查找用户
        public ActionResult ChatSearch(string searchString)
        {
            ViewBag.keyword = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                var user = mailmanager.SearchUsers(searchString);
                ViewBag.sum = user.Count();      //统计查询出歌曲的数量
                return View(user);
            }
            else
            {
                ViewBag.sum = 0;
                return View();
            }

        }
        #endregion

    }
}