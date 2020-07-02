using System;
using System.Linq;
using System.Web.Mvc;
using VoiceSingWeb.Models;
using System.IO;
using System.Data.Entity.Validation;
using BLL;
using Models;
using System.Web;
using System.Collections.Generic;

namespace VoiceSingWeb.Controllers
{
    public class CampController : Controller
    {
        UserManager usermanager = new UserManager();
        ActiveManager activemanager = new ActiveManager();


        SingMusicDataBaseEntities db = new SingMusicDataBaseEntities();
        // GET: Camp
        public ActionResult Index()
        {
            return View();
        }

        #region 活动详情页
        public ActionResult CampDetails(int id)
        {
            var camp = db.Active.Where(o => o.actno == id).SingleOrDefault();
            return View(camp);
        }
        #endregion



        #region 活动首页展示三个活动排除屏蔽内容
        public ActionResult Camp1()          //还没有实现异步刷新
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var hideact = activemanager.GetHideActive(id).ToList();       //获取该用户屏蔽活动
            List<Active> allact = activemanager.GetAllActive().ToList();           //获取所有活动

            foreach (var item in hideact)
            {
                for (int i = 0; i < allact.Count(); i++)
                    if (allact[i].actno == item.activeid)
                    {
                        allact.RemoveAt(i);
                    }
            }
        
            return View(allact);
            
        }
        #endregion

        #region 活动页面我的发布
        public ActionResult mycamp()    
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var mycamp = activemanager.GetActiveById(id);
           // var mycamp = db.Active.Where(o => o.Holder == id);
            return View(mycamp);
        }
        #endregion

        #region 猜你喜欢likecamp
        public ActionResult likecamp()     //猜你喜欢 
        {
            var likecamp = activemanager.GetActiveByHolder();
            //var likecamp = db.Active.Where(o => o.Holder == 20191048).Take(3);
            return View(likecamp);
        }
        #endregion

        #region 活动页面展示所有活动
        public ActionResult allcamp()    
        {
            var all = activemanager.GetAllActive();
           // var all = db.Active.Where(o => o.actno < 20).Take(10);
            return View(all);
        }
        #endregion

        #region    活动页面历史参与 
        public ActionResult usedcamp()  
        {
            var used = activemanager.GetActiveByLocation();
            //var used = db.Active.Where(o => o.Location == 1).Take(3);
            return View(used);
        }
        #endregion

        #region 发布活动 publish    
        public ActionResult Publish()    
        {
            if (Session["UserId"] != null && Session["Username"] != null)
            {               
                return View();
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Publish (FormCollection forms, Active active)
        {

            if (Session["UserId"] != null && Session["UserName"] != null)    //用户功能，需要登录
            {
                try
                {
                    //获取活动封面
                    HttpPostedFileBase activeImg = Request.Files["activeImg"];
                    string dbimg_url = "";
                    string savefilePath2 = "";
                    //判断文件是否为空
                    if (activeImg != null)
                    {
                        //获取文件类型
                        string fileExtension = Path.GetExtension(activeImg.FileName);
                        //自定义文件名（时间+唯一标识符+后缀）
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                        //判断是否存在需要的目录，不存在则创建 
                        if (!Directory.Exists(Server.MapPath("~/Content/images/Camp")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Content/images/Camp"));
                        }
                        //拼接保存文件的详细路径
                        savefilePath2 = Server.MapPath("~/Content/images/Camp/") + fileName;
                        //若扩展名不为空则判断文件是否是指定视频类型
                        if (fileExtension != null)
                        {
                            if ("(.bmp)|(.png)|(.jpg)|(.gif)|(.jpeg)|(.BMP)|(.PNG)|(.JPG)|(.GIF)|(.JPEG)".Contains(fileExtension))
                            {
                                //拼接返回的Img标签
                                dbimg_url = "../../Content/images/Camp/" + fileName;
                            }
                        }
                        else
                        {
                            dbimg_url = "没有找到该文件！";
                        }                       
                    }
                    else
                    {
                        return Content("没有找到该文件！");
                    }

                    var actname = forms["actname"];   
                    var actinfo = forms["actinfo"];
                    var orienroll = forms["orienroll"];
                    var recenroll = forms["recenroll"];
                    var image_url = dbimg_url;
                    var Holder = Convert.ToInt32(Session["UserId"]);

                    var publish = activemanager.PublishActive(actname, actinfo, orienroll, recenroll, image_url, Holder);
                    if (publish == "success")
                    {
                        return Content("<script>alert('上传成功！');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("<script>alert('上传失败！');history.go(-1)</script>");
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    return Content(dbEx.Message);
                }
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }

        #endregion

        #region  屏蔽活动 Hide - ActiveHide

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Hide (FormCollection forms)
        {
            // if (ModelState.IsValid)
            // {
            //  if ("id" != "" && "userid" != "")
            //  {
            var id = Convert.ToInt32(forms["id"]);
            var userid = Convert.ToInt32(Session["UserId"]);

            string msg = activemanager.HideActive(id, userid);
                    if (msg == "exist")
                    {
                        return Content("fail");
                        //return Content("<script>alert('您已屏蔽！');history.go(-1)</script>");
                    }
                    else if (msg == "success")
                    {
                        return Content("success");
                        //return Content("<script>alert('屏蔽成功！');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("fail");
                        //return Content("<script>alert('屏蔽失败！');history.go(-1)</script>");
                    }
               // }
          
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Camp");
            //}
        }
        #endregion

        #region 通过修改状态实现对活动的  投诉  屏蔽
        public ActionResult Complain (int id)
        {
            //id = Convert.ToInt32(id);
            var active = activemanager.GetActiveByActno(id);
            return View(active);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complain(FormCollection forms)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var id = forms["actid"];
            var actid = Convert.ToInt32(id);
            var content = forms["content"];
            var complain = activemanager.ComplainActive(userid, actid, content);
            
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
    }
}